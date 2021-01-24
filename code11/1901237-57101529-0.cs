        public override Task OnConnected()
        {
            if(Context.QueryString["CustomToken"] != "CorrectToken")
            {
                ///Forcefully close the connection
                HttpContext.Current.Response.Close();
            }
            return base.OnConnected();
        }
