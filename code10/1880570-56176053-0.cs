	using System;
	using System.Data.Entity;
	using System.Linq;
	using System.Linq.Expressions;
	using System.Threading.Tasks;
	using Z.EntityFramework.Plus; 
	class Program
	{
		static async Task Main(string[] args)
		{
			using (var context = new SomeContext())
			{
				await context
					.Customers
					.Where(c => c.Email.Contains("42"))
					.CustomUpdateAsync((c) => new Customer()
					{
						Email = "4242"
					});
			}
		}
	}
	public static class Helper
	{
		public static async Task<int> CustomUpdateAsync<T>(this IQueryable<T> queryable, Expression<Func<T, T>> updateFactory)
			where T : class
		{
			var targetType = typeof(T);
			if (typeof(ITrackModifiedDate).IsAssignableFrom(targetType))
			{
				updateFactory = (Expression<Func<T, T>>)new TrackModifiedDateVisitor().Modify(updateFactory);
			}
			return await BatchUpdateExtensions.UpdateAsync(queryable, updateFactory);
		}
	}
	public class TrackModifiedDateVisitor : ExpressionVisitor
	{
		public Expression Modify(Expression expression)
		{
			return Visit(expression);
		}
		public override Expression Visit(Expression node)
		{
			if (node is MemberInitExpression initExpression)
			{
				var existingBindings = initExpression.Bindings.ToList();
				var modifiedProperty = initExpression.NewExpression.Type.GetProperty(nameof(ITrackModifiedDate.ModifiedDate));
				// it will be `some.ModifiedDate = currentDate`
				var modifiedExpression = Expression.Bind(
					modifiedProperty,
					Expression.Constant(DateTime.Now, typeof(DateTime))
					);
				existingBindings.Add(modifiedExpression);
				// and then we just generate new MemberInit expression but with additional property assigment
				return base.Visit(Expression.MemberInit(initExpression.NewExpression, existingBindings));
			}
			return base.Visit(node);
		}
	}
	public class SomeContext: DbContext
	{
		public SomeContext()
			: base("Data Source=.;Initial Catalog=TestDb;Integrated Security=SSPI;")
		{
			Database.SetInitializer(new CreateDatabaseIfNotExists<SomeContext>());
		}
		public DbSet<Customer> Customers { get; set; }
	}
	public class Customer: ITrackModifiedDate
	{
		public int ID { get; set; }
		public string Email { get; set; }
		public DateTime ModifiedDate { get; set; }
	}
	public interface ITrackModifiedDate
	{
		DateTime ModifiedDate { get; set; }
	}
