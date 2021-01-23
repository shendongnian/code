    public interface ICallable { string CallerIdString(); }
    
    public class Person : ICallable
    {
    	private static class TelephoneLine
    	{
    		public static string sharedString = string.Empty;
    		public static void NotifyOnCall()
    		{
    			//notify if someone call this person
    		}
    		public static void Comunicate<TCaller>(TCaller Caller, Person comunicateWith, string message) where TCaller : ICallable
    		{
    			sharedString = "Sender: " + Caller.CallerIdString() + " To: " + comunicateWith.Name +
    						   " said: " + message;
    						   sharedString.Dump();
    		}
    	}
    	public Person(string name)
    	{
    		Name = name;
    	}
    	string Name;
    	public void CallTo(Person person, string message)
    	{
    		TelephoneLine.Comunicate<Person>(this, person, message);
    	}
    	public void ShowCall()
    	{
    		Console.Write(TelephoneLine.sharedString);
    	}
    	
    	public string CallerIdString() { return this.Name;}
    }
