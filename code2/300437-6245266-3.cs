            Exception ex = Server.GetLastError();
            string uri = null;
            if (Context != null && Context.Request != null)
            {
                uri = Context.Request.Url.AbsoluteUri;
            }
            Exception baseEx = ex.GetBaseException();
             var httpEx = ex as HttpException;
             if ((httpEx != null && httpEx.GetHttpCode()==404) 
                  || (uri != null && Context.Response.StatusCode == 404) )
                 { /* do what you want. */ 
                   //Example: show some known url
                   Server.ClearError();
                   Server.TransferRequest(transferUrl);
                 }
