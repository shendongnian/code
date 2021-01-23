    protected void Page_Load(object sender, EventArgs e)
    {
    if (Page.IsPostBack)
    {
    WebControl wcICausedPostBack = (WebControl)GetControlThatCausedPostBack(sender as Page);
    int indx = wcICausedPostBack.TabIndex;
    var ctrl = from control in wcICausedPostBack.Parent.Controls.OfType<WebControl>()
    where control.TabIndex > indx
    select control;
    ctrl.DefaultIfEmpty(wcICausedPostBack).First().Focus();
    }
    }
    protected Control GetControlThatCausedPostBack(Page page)
    {
    Control control = null;
    string ctrlname = page.Request.Params.Get("__EVENTTARGET");
    if (ctrlname != null && ctrlname != string.Empty)
    {
    control = page.FindControl(ctrlname);
    }
    else
    {
    foreach (string ctl in page.Request.Form)
    {
    Control c = page.FindControl(ctl);
    if (c is System.Web.UI.WebControls.Button || c is System.Web.UI.WebControls.ImageButton)
    {
    control = c;
    break;
    }
    }
    }
    return control;
    }
