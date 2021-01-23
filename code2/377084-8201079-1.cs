	public class MyCustomers : ServiceBase<Customers>
	{
		public override object Run(Customers request)
		{
		   return new List<Customers>() { 
		       new Customers() { id = 1, Name = "murat", SurName = "xyzk" }, 
		       new Customers() { id = 2, Name = "ali", SurName = "Yılmaz" } };
		}
	}
