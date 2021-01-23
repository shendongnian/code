    public partial class Default : System.Web.UI.Page
    {
    List<Control> lstControl = new List<Control>();
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    private List<Label> getLabels() // Add all Lables to a list
    {
        List<Label> lLabels = new List<Label>();
        foreach (Control oControl in Page.Controls)
        {
            GetAllControlsInWebPage(oControl);
        }
        foreach (Control oControl in lstControl)
        {
            if (oControl.GetType() == typeof(Label))
            {
                lLabels.Add((Label)oControl);
            }
        }
        return lLabels;
    }
    protected void GetAllControlsInWebPage(Control oControl)
    {
        foreach (Control childControl in oControl.Controls)
        {
            lstControl.Add(childControl); //lstControl - Global variable
            if (childControl.HasControls())
                GetAllControlsInWebPage(childControl);
        }
    }
    }
