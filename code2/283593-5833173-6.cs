    namespace StackOverFlowSpike.Attributes
    {
    	[AttributeUsage(AttributeTargets.Property)]
    	public class ReadOnlyAttribute : Attribute
    	{
    		public ReadOnlyAttribute() { }
    	}
    }
    using StackOverFlowSpike.Attributes;
    
    namespace StackOverFlowSpike.Entities
    {
    	public interface IEntity
    	{
    		[ReadOnly]
    		public int Id { get; set; }
    	}
    }
    using System;
    using StackOverFlowSpike.Attributes;
    
    namespace StackOverFlowSpike.Entities
    {
    	public class Product : IEntity
    	{
    		[ReadOnly]
    		public int Id { get; set; }
    		
    		public string Name { get; set; }
    		public decimal Price { get; set; }
    		
    		[ReadOnly]
    		public DateTime Created { get; set; }
    		
    		[ReadOnly]
    		public DateTime Updated { get; set; }
    	}
    }
    using StackOverFlowSpike.Entities;
    using System.Collections.Generic;
    
    namespace StackOverFlowSpike.Repositories
    {
    	public interface IRepository<T> where T : IEntity
    	{
    		void Add(T item);
    		void Update(T item);
    		T Get(int id);
    		IEnumerable<T> GetAll();
    	}
    }
    using System;
    using System.Linq;
    using System.Threading;
    using System.Reflection;
    using System.Collections.Generic;
    using StackOverFlowSpike.Entities;
    using StackOverFlowSpike.Attributes;
    
    namespace StackOverFlowSpike.Repositories
    {
    	public class ProductRepositoryMock : IRepository<Product>
    	{
    		#region Fields and constructor
    
    		private IList<Product> _productsStore;
    
    		public ProductRepositoryMock()
    		{
    			_productsStore = new List<Product>();
    		}
    
    		#endregion
    
    		#region private methods
    
    		private int GetNewId()
    		{
    			return _productsStore
    				.OrderByDescending(p => p.Id)
    				.Select(p => p.Id).FirstOrDefault() + 1;
    		}
    
    		private void PopulateProduct(Product storedProduct, Product incomingProduct)
    		{
    			foreach (var p in storedProduct.GetType().GetProperties())
    			{
    				// check if it is NOT decorated with ReadOnly attribute
    				if (!(p.GetCustomAttributes(typeof(ReadOnlyAttribute), false).Length > 0))
    				{
    					// i will use reflection to set the value
    					p.SetValue(storedProduct, p.GetValue(incomingProduct, null), null);
    				}
    			}
    		}
    
    		private void Synchronise(Product storedProduct, Product incomingProduct)
    		{
    			foreach (var p in storedProduct.GetType().GetProperties())
    				p.SetValue(incomingProduct, p.GetValue(storedProduct, null), null);
    		}
    
    		#endregion
    
    		public void Add(Product product)
    		{
    			Product newProduct = new Product();
    			newProduct.Id = GetNewId();
    			newProduct.Created = DateTime.Now;
    			newProduct.Updated = DateTime.Now;
    
    			PopulateProduct(newProduct, product);
    			_productsStore.Add(newProduct);
    			Synchronise(newProduct, product);
    
    			// system takes a quick nap so we can it really is updating created and updated date/times
    			Thread.Sleep(1000);
    		}
    
    		public void Update(Product product)
    		{
    			var storedProduct = _productsStore.Where(p => p.Id == product.Id).FirstOrDefault();
    
    			if (storedProduct != null)
    			{
    				PopulateProduct(storedProduct, product);
    				storedProduct.Updated = DateTime.Now;
    
    				// system takes a quick nap so we can it really is updating created and updated date/times
    				Synchronise(storedProduct, product);
    				Thread.Sleep(1000);
    			}
    		}
    
    		public Product Get(int id)
    		{
    			Product storedProduct = _productsStore.Where(p => p.Id == id).FirstOrDefault();
    			Product resultProduct = new Product()
    			{
    				Id = storedProduct.Id,
    				Name = storedProduct.Name,
    				Price = storedProduct.Price,
    				Created = storedProduct.Created,
    				Updated = storedProduct.Updated
    			};
    
    			return resultProduct;
    		}
    
    		public IEnumerable<Product> GetAll()
    		{
    			return _productsStore;
    		}
    	}
    }
