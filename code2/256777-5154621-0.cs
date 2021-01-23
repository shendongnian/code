    public string GetPath()
    {
     
     if(Assembly.GetCallingAssembly().FullName == "WebProjectDLLName")
     {
       //From web project 
     }
     else
     {
       // other than web project
     }
    }
