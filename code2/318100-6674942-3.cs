    public partial class WebForm1 : System.Web.UI.Page
    {
        public WebForm1()
        {
            //Register the handler via code in the constructor
            Load += CommonEventHandlers.Page_Loaded;
        }
    }
