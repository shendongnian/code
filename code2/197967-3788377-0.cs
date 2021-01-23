    public Application GetApplicationAndAssistantsByApplicationID(int applicationID)
    {
       var application =
          (from a
          in context.GetApplicationByID(applicationID)
          select a).FirstOrDefault();
       
       // call your other stored procedure...
       var assistants = context.GetAssistantsByApplicationID(applicationID)
                               .ToArray();
       // as the assistants are materialized they will automatically show up
       // in application.Assistants too.
    
       return application;
    }
