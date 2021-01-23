    using System;
    
    public partial class _Default : System.Web.UI.Page 
    {
        string eventName = String.Empty;
    
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write(eventName);
        }
    
        protected void Page_PreInit(object sender, EventArgs e)
        {
            eventName = "Page_PreInit";
        }  
        
        protected override void OnPreInit(EventArgs e)
        {
           base.OnPreInit(e);
           eventName = "OnPreInit";
        }
    }
