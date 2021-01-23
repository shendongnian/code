    http://www.mydomain.com/mypage.com?iView=mySecondView
    
    partial class MyControl : System.Web.UI.WebControl
    {
        // blah blah control stuff
    
        public string getRequestedView()
        {
            return (Request.QueryString["iView"]) ? Request.QueryString["iView"] : String.Empty;
        }
    }
    
    ...
    
    protected void Page_Load(object sender, EventArgs e)
    {
        View myView = myMultiView.FindControl(this.getRequestedView());
        if(myView != null)
            this.MyView.SetActiveView(myView);
    }
