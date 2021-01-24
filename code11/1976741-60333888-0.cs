public class Program
{
	public static void Main()
	{
		List<Parent<IParent>> parentList = new List<Parent<IParent>>();
		
		parentList.Add(new Child1());
		parentList.Add(new Child2());		
	}
}
public class Parent<T> 
{ }
public interface IParent
{ }
public class Child1 : Parent<IParent>, IParent
{ }
public class Child2 : Parent<IParent>, IParent
{ }
