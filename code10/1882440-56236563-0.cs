    public class Program
    {
	    public static void Main()
    	{
	    	BaseClass c = new ExtendedClass() { id= 2, name = "Jhon"};
		
		    ExtendedClass extended = c as ExtendedClass;		
    		Console.WriteLine(extended.name);
	    }
    }
    public class BaseClass 
    {
        public int id{ get; set; }
        public string name { get; set; }
        public string description { get; set; }
    }
    public class ExtendedClass : BaseClass 
    {
        public int quantity { get; set; }
        public string moreDetail{ get; set; }
    }
