	using System;
	using System.Linq.Expressions;
	using System.Reflection;
	public class Program
	{
		public static void Main()
		{
			var orderDto = new OrderDto
			{
				Id = 1,
				Name = "Name",
				CreatedOn = DateTime.UtcNow,
				CompletedOn = DateTime.UtcNow.AddMinutes(30),
				Misc = Guid.NewGuid()
			};
			Console.WriteLine($"{orderDto.Id} {orderDto.Name} {orderDto.CreatedOn} {orderDto.CompletedOn} {orderDto.Misc}");
			orderDto.DefaultFor(x => x.Id, x => x.Name, x => x.CreatedOn, x => x.CompletedOn);
			Console.WriteLine($"{orderDto.Id} {orderDto.Name} {orderDto.CreatedOn} {orderDto.CompletedOn} {orderDto.Misc}");
		}
	}
	public static class ObjectExtensions
	{
		public static void DefaultFor<TObject, TProp1, TProp2, TProp3, TProp4>(this TObject instance, 
			Expression<Func<TObject, TProp1>> selector1, 
			Expression<Func<TObject, TProp2>> selector2,
			Expression<Func<TObject, TProp3>> selector3,
			Expression<Func<TObject, TProp4>> selector4)
			where TObject : class
		{
			DefaultFor(instance, selector1, selector2, selector3);
			DefaultFor(instance, selector4);
		}
		public static void DefaultFor<TObject, TProp1, TProp2, TProp3>(this TObject instance, 
			Expression<Func<TObject, TProp1>> selector1, 
			Expression<Func<TObject, TProp2>> selector2,
			Expression<Func<TObject, TProp3>> selector3)
			where TObject : class
		{
			DefaultFor(instance, selector1, selector2);
			DefaultFor(instance, selector3);
		}
		public static void DefaultFor<TObject, TProp1, TProp2>(this TObject instance, 
			Expression<Func<TObject, TProp1>> selector1, 
			Expression<Func<TObject, TProp2>> selector2)
			where TObject : class
		{
			DefaultFor(instance, selector1);
			DefaultFor(instance, selector2);
		}
		public static void DefaultFor<TObject, TProp>(this TObject instance, Expression<Func<TObject, TProp>> selector)
			where TObject : class
		{
			if (instance == null)
				throw new ArgumentNullException();
			var memberExpression = (MemberExpression)selector.Body;
			var property = (PropertyInfo)memberExpression.Member;
			property.SetValue(instance, default(TProp));
		}
	}
	public class OrderDto
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public DateTime CreatedOn { get; set; }
		public DateTime? CompletedOn { get; set; }
		public Guid Misc { get; set; }
	}
