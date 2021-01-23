    public static void Log(Expression<Action> expr)
    {
        Console.WriteLine(((MethodCallExpression)expr.Body).Method.Name);
    }
    
    void Main()
    {
    	Log(() => DoIt());
    	Log(() => DoIt2(null));
    	Log(() => DoIt3());
    }
    
    public void DoIt()
    {
        Console.WriteLine ("Do It!");
    }
    
    public void DoIt2(string s)
    {
        Console.WriteLine ("Do It 2!" + s);
    }
    
    public int DoIt3()
    {
        Console.WriteLine ("Do It 3!");
        return 3;
    }
