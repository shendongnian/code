        [WebMethod]
        public static string GetControlViaAjax()
        {
            Dictionary<string, object> d = new Dictionary<string, object>();
            d.Add("CssClass", "YourCSSClass");
            d.Add("Title", "Your title");
            return RenderUserControl("/yourcontrol.ascx", true, d, "Com.YourNameSpace.UI", "AwesomeControl");
        }  
