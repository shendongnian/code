    public partial class error_NotFound : Custom.PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError();
            //do something with the exception
            Server.ClearError();
            Response.StatusCode = 404; 
        }    
    }
