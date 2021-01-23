    void Main()
    {	
	DerivedClass dc = new DerivedClass("hello, world");
	Console.Out.WriteLine(dc);	
	string result = dc.Notify("greetings");
	Console.Out.WriteLine(result);
    }
    public interface IPartImportsSatisfiedNotification
    {
	string Notify(string msg);
    }
    public abstract class MyClass  : IPartImportsSatisfiedNotification
    {
       protected string name; 
       public MyClass(string name)
       {
	   this.name = name; 
       }
   
       abstract public string Notify(string msg);
   
     }
 
     public class DerivedClass : MyClass
     {
 	public DerivedClass(string name) :base(name)
	{
		
	}
	
	public override string Notify(string msg)
	{
		return string.Format("Msg {0} from {1}", msg, this.name);
	}
	
	public override string ToString() 
	{
		return this.name;
	}
     }
