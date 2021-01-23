    private void DivideByZero()
    {
    try
    {
        int x = 2/0;
    }
    cath(Exception ex)
    {
        Console.Writeline(ex.ToString());
        throw;
    }
    }
    
    void Main(string[] a)
    {
        try
        {
           DivideByZero();
        }
        catch(Exception x)
        {
            // write logging code here .. 
        }
      
    }
