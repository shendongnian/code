    using System;
    using System.Text;
    using System.Collections.Generic;
    using StackOverFlowSpike.Entities;
    using StackOverFlowSpike.Repositories;
    
    namespace StackOverFlowSpike
    {
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			Product p1 = new Product()
    			{
    				Created = Convert.ToDateTime("01/01/2012"), // ReadOnly - so should not be updated with this value
    				Updated = Convert.ToDateTime("01/02/2012"), // ReadOnly - so should not be updated with this value
    				Id = 99, // ReadOnly - should not be udpated with this value
    				Name = "Product 1",
    				Price = 12.30m
    			};
    
    			Product p2 = new Product()
    			{
    				Name = "Product 2",
    				Price = 18.50m,
    			};
    
    			IRepository<Product> repo = new ProductRepositoryMock();
    
    			// test the add
    			repo.Add(p1);
    			
    			repo.Add(p2);
    			PrintProducts(repo.GetAll());
    
    			// p1 should not change because of change in Id
    			p1.Id = 5; // no update should happen
    			p1.Name = "Product 1 updated";
    			p1.Price = 10.50m;
    
    			// p2 should update name and price but not date created
    			p2.Name = "Product 2 updated";
    			p2.Price = 17m;
    			p2.Created = DateTime.Now;
    
    			repo.Update(p1);
    			repo.Update(p2);
    			PrintProducts(repo.GetAll());
    
    			Console.ReadKey();
    		}
    
    		private static void PrintProducts(IEnumerable<Product> products)
    		{
    			foreach (var p in products)
    			{
    				Console.WriteLine("Id: {0}\nName: {1}\nPrice: {2}\nCreated: {3}\nUpdated: {4}\n",
    					p.Id, p.Name, p.Price, p.Created, p.Updated);
    			}
    
    			Console.WriteLine(new StringBuilder().Append('-', 50).AppendLine().ToString());
    		}
    	}
    }
