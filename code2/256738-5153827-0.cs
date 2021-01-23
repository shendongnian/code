        var exceptionMessage = new StringBuilder();  
        
        try
        {
        }
        catch(EntityValidationException exc)
        {  
            exceptionMessage.Append(exc.InnerException.Message);  
        }  
        catch(ValidationException exc)  
        {  
            exceptionMessage.Append(exc.InnerException.Message);  
        }  
        ....
