    using System;
    					
    public class Program
    {
    	public static void Main()
    	{
    		var b = new Book();
    		b.SetMyField(1);
    		Console.WriteLine(b.MyField);
    		b.SetMyField('A');
    		Console.WriteLine(b.MyField);
    	}
    }
    
    
    public interface IMySerializable {
    	object MyField { get; }
    	void SetMyField( int val);
    	void SetMyField( char val);
    	void SetMyField( byte val);
    }
    
    public class Book : IMySerializable {
    	
    	public object MyField { 
    		get; 
    		private set;
    	}
    	
    	public void SetMyField( int val){
    		MyField=val;
    	}
    	
    	public void SetMyField( char val){
    		MyField=val;
    	}
    	
    	public void SetMyField( byte val){
    		MyField=val;
    	}
    }
