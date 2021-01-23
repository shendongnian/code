    void MyMainMethod()
    {
        
        // ... oh, let's call my Method with some arguments
        // I'm not sure if it'll work, so best to wrap it in a try catch
    
        try
        {
            Method(-100, 500);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    
    }
      
    
    public int Method(int a, int b)
    {
        if (a < b) throw new ArgumentException("the first argument cannot be less than the second");
       
        //do stuff ...  and return 
    
    }
