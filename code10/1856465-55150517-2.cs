    public void Main()
    {
        try{
    
            string _SharedBox = "user@domain.com";
            ExchangeService service = new ExchangeService();
            service.AutodiscoverUrl(_SharedBox);
            service.UseDefaultCredentials = true;
            //... goes on, but the rest is commented out for now.
            Dts.TaskResult = (int)ScriptResult.Success;
    
        }catch(Exception ex){
    
            Dts.FireError(0,"An error occured", ex.Message,String.Empty, 0);
            Dts.TaskResult = (int)ScriptResult.Failure;
    
        }
    
    
    }
