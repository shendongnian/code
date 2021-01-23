    public class Finalised
    {
    	~Finalised()
    	{
    		Program.WriteMessage("In finaliser");
    	}
    }
    class Program
    {
    	private static object syncLock = new object();
    	private static List<string> messages = new List<string>();
    
    	static void Main(string[] args)
    	{
    		Finalised f = new Finalised();
    		f = null;
    
    		GC.Collect();
    		GC.WaitForPendingFinalizers();
    
    		WriteMessage("Exiting...");
    
    		foreach (string msg in messages)
    		{
    			Console.WriteLine(msg);
    		}
    	}
    
    	public static void WriteMessage(string message)
    	{
    		lock (syncLock)
    		{
    			messages.Add(message);
    		}
    	}
    }
