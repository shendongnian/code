	public static void Main()
	{
		Derived d = new Derived();
		Console.WriteLine(d.AsReadOnly().Count);
		d.AddElement(new GenericObject { i = 2 });
		Console.WriteLine(d.AsReadOnly().Count);
	}
	
	public class Base<T>
	{
		List<T> _items = new List<T>();
	
		public ReadOnlyCollection<T> AsReadOnly()
		{
			return Array.AsReadOnly(_items.ToArray());
		}
	
		public void AddElement(T obj)
		{
			_items.Add(obj);
		}
	
		public void RemoveElement(T obj)
		{
			_items.Remove(obj);
		}
	}
	
	public class Derived : Base<GenericObject>
	{
	}
	
	public class GenericObject
	{
		public int i = 0;
	}
