    public int bla()
    {
       try{
         //your code
       }catch(Exception ex){
          System.Diagnostics.Debugger.Break();
          Console.WriteLine(ex.Message);
          return -1;
       }
    }
