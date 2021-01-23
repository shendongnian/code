     try{
                //Code which may throw an error
        }
        catch(Exception ex){
                ErrorLog.GetDefault(HttpContext.Current).Log(new Elmah.Error(ex));
        }
