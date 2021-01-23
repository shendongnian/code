    public class MyClass 
    {
        ErrorForm ew = null; 
    
        public void Validate() 
        {
           if(ew !=null && !ew.IsDisposed) 
              ew.Close(); 
    
           ew =  new ErrorForm(Errors);
           ew.Show();
        }
    }
