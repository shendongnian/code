    void Main()
    {
    	Func<int> m1=()=>1;
    	Console.WriteLine(A(m1));
    	
    	Func<int,int> m2=i=>i;
    	Console.WriteLine(A(m2,55));
    }
    
    object A(Delegate B,params object[] args)
    {
    	
    	return B.Method.Invoke(B.Target,args);
    }
