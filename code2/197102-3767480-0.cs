    class Program
    {
    	static void Main(string[] args)
    	{
    		var f = new Foo();
    		foreach (var fi in f.GetType().GetProperties(
                                   BindingFlags.NonPublic | BindingFlags.Instance))
    		{
    			Console.WriteLine(fi);
    		}
    	}		
    }
    
    public class Foo
    {
    	private string Prop { get; set; }
    }
