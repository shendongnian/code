    public class DataLogOut
    {
        // No need for this, we will use "EventHandler"
        // public delegate void OnLogoutResponse(ResponseData data);
        //public event OnLogoutResponse onLogoutResponse; -> replaced by
        public event EventHandler<ResponseData> onLogoutResponse;
    
        // Convenience Method to fire the event
        protected virtual void OnLogoutResponse( ResponseData data )
        {
             var handler = onLogoutResponse;
             if( handler != null ){
                handler( this, data );
             }
        }
       
        // Let's simplify it by making it non-static
        //public static void LogoutPlayer()
        public void LogoutPlayer
        {
    
            new EndSessionRequest().SetDurable(true).Send((response) => {
                if (!response.HasErrors)
                {
    
                    GS.Reset();
                        
                    OnLogoutResponse(new ResponseData()
                    {
                       //data = response
                    });
                }
                else
                {
                    OnLogoutResponse(new ResponseData()
                    {
                        errors = response.Errors,
                        hasErrors = response.HasErrors
                    });
                }
            });
    
        }
    }
