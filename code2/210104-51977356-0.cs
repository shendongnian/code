    //Wrapper code
    public delegate void MyAction(params object[] objArgs);
    public static void RunActions(params MyAction[] actnArgs)
    {
        Console.WriteLine("WrapperBefore: Begin transaction code\n");
        actnArgs.ToList().ForEach( actn =>  actn() );
        Console.WriteLine("\nWrapperAfter: Commit transaction code");
    }
    
    //Methods being called
    public void Hash  (string s, int i, int j)  => Console.WriteLine("   Hash-method call: " + s + "###" + i.ToString() + j.ToString());
    public void Slash (int i, string s)         => Console.WriteLine("   Slash-method call: " + i.ToString()+ @"////" + s);
    
    //Actual calling code
    void Main()
    {  
      RunActions( objArgs => Hash("One", 2, 1)
                 ,objArgs => Slash(3, "four")   );
    }
    //Resulting output: 
    // 
    //  WrapperBefore: Begin transaction code
    //  
    //  Hash-method call: One###21
    //  Slash-method call: 3////four
    //  
    //  WrapperAfter: Commit transaction code  
