      public partial class ScheduleEdit : System.Web.UI.Page,
            System.Web.UI.IPostBackEventHandler
        {
            protected void Page_Init(object sender, EventArgs e)
            {
                var postBack = Page.ClientScript.GetPostBackEventReference(this, null);
        
                var script = "function postback() { " + postBack + "; }";
        
                Page.ClientScript.RegisterStartupScript(GetType(), this.UniqueID, script, true);
            }
        
            // this is called via the client side 'postback' script
            public void RaisePostBackEvent(string eventArgument)
            {
                DoStuff();
            }
        }
        
        
        // client side script:
        $("#DP").datepicker({
            onSelect: function (dateText, inst) { postback(); },
         });
