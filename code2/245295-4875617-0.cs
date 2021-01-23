    public class MyForm : System.Windows.Forms.Form
    {
    	int myInt;
    
    	public MyForm()
    	{
    		myInt = 1;
    
    		//1
    		var myClass = new MyClass(myInt);
    
    		//2
    		myClass.MyInt = myInt;
    	}
    }
    
    public class MyClass
    {
    	public int MyInt { get; set; }
    
    	public MyClass(int myInt)
    	{
    		MyInt = myInt;
    	}
    }
