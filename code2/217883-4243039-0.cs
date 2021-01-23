    public partial class YourPage : System.Web.UI.Page
    {
        XTContext.UserContext UContext; 
        XTContext.Context ctxt; 
        XTErrorCollection.ErrorCollection eContext;
        protected void Page_Load(object sender, EventArgs e)
        {
            UContext = new XTContext.UserContext();
            ctxt = new XTContext.Context();
            eContext = new XTErrorCollection.ErrorCollection();                       
            ctxt = (XTContext.Context)Cache["sessionfContext"];
            ctxt.eContext = eContext;
            ctxt.uContext = UContext;
        }
    }
