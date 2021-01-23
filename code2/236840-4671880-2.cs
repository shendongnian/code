	public static T Save<T>(T item) where T : Base, new()
	{
	  if (item.Id == Guid.Empty && (Check(repository, item)))
	  {
		throw new Exception("Name is not unique");
	  }
	}
	public class Base
	{
	  ...
	  public Func<Enumerable<T>, T, bool> Check { get; set;}
	  
	  public Base()
	  {
		Check = (col, newItem) => (null != col.FirstOrDefault<T>(
                                           item => item.Name == newItem.Name));
	  }
	}
