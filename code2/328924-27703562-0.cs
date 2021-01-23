    protected void Application_AcquireRequestState(object sender, EventArgs e)
        {
            /// Using from Try-Catch to handle "Session state is not available in this context." error.
            try
            {
                //must incorporate error handling because this applies to a much wider range of pages 
                //let the system do the fallback to invariant 
                if (Session["_culture"] != null)
                {
                    System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(Session["_culture"].ToString());
                    //it's safer to make sure you are feeding it a specific culture and avoid exceptions 
                    System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(Session["_culture"].ToString());
                }
            }
            catch (Exception ex)
            {}
        }
