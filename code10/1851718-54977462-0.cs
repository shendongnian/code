cs
using System;
interface IRepoInterface
{
	string test();
}
class BaseRepository : IRepoInterface
{
 	public string test()
    {
        return "Test String in implementing class";
    }
}
class ChildRepository : BaseRepository
{
    public string SomeFunctionName()
    {
        return "Test String in child class";
    }
}
	
public class Program
{
	public static void Main()
	{
		ChildRepository repo = new ChildRepository();
		Console.WriteLine(repo is ChildRepository);
		Console.WriteLine(repo is BaseRepository);
		Console.WriteLine(repo is IRepoInterface);
	}
}
In above code snippet, class BaseRepository implements the Interface and class ChildRepository extends class BaseRepository. 
So any object of class ChildRepository will pass for type checking for ChildRepository, BaseRepository and IRepoInterface.
