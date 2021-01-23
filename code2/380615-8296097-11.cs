        [WebMethod]
        public static string GetControlViaAjax()
        {
            Dictionary<string, object> d = new Dictionary<string, object>();
            d.Add("CssClass", "YourCSSClass");
            d.Add("Title", "Your title");
            return RenderUserControl("/yourcontrol.ascx", true, d, null, null);
            //use this one if your controls are compiled into a .dll
            //return RenderUserControl(null, true, d, "Com.YourNameSpace.UI", "AwesomeControl");
          
        }  
