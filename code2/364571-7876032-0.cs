    public class MyClassEnglish
	{
	    public virtual string SomethingToSay()
		{
		    return "Hello!";
		}
		
		public void WriteToConsole()
		{
		    Console.WriteLine(this.SomethingToSay());
		}
	}
	
	public class MyClassItalian :
	    MyClassEnglish
	{
	    public override string SomethingToSay()
		{
		    return "Ciao!";
		}
	}
	
	int main()
	{
	    MyClassItalian it = new MyClassItalian();
		
		it.WriteToConsole();
	}
