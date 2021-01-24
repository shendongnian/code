    [ValidateInput(false)]
            protected void Application_Error()
            {
                
                 //prevent the errors coming back!
                 this.Context.ClearError();
    
                 //redirect
                 this.Context.Response.Redirect($"~/Home/Error");
            }
