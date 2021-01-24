    using System;
    
    public class BoolVariable {
        public bool Value;
    }
    
    public class BoolReference {
    
    private BoolVariable Variable;
    
    public bool Value {
        get => Variable.Value;
        set {
            Variable.Value = value;
        }
    }
    
    public static implicit operator bool(BoolReference bRef) => bRef.Value;
    public static implicit operator BoolReference(bool b){
    	BoolReference br = new BoolReference();
        br.Variable = new BoolVariable();
    	br.Value=b;
    	return br;
    }
    
    }	
    public class Program
    {
    	static BoolReference r;
    	public static void Main()
    	{
    		r = false;
    		Console.WriteLine(r);
    		r = true;
    		Console.WriteLine(r);
    	}
    }
