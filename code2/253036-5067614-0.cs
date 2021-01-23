    public delegate void ConsoleCmd();
    
    public class DefaultCommands
    {
    	public static void Nick()
    	{
    		Console.WriteLine("I'm Nick!");
    	}
    
    	public static void LogOut()
    	{
    		Console.WriteLine("You're Fired!");
    	}
    }
    
    public class Console
    {
    	private Dictionary<string, ConsoleCmd> mCommands;
    
    	public Console()
    	{
    		mCommands = new Dictionary<string, ConsoleCmd>();
    		mCommands.Add("Nick", DefaultCommands.Nick);
    		mCommands.Add("Logout", DefaultCommands.LogOut);
    	}
    }
