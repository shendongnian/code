    public partial class About : System.Web.UI.Page
        {
            protected override void OnInit(EventArgs e)
            {
                if (!IsPostBack)
                {
                    //Initially add the view state variable
                    ViewState.Add("DetailsViewMode", DetailsViewMode.ReadOnly);
                   
                }
                base.OnInit(e);
            }
    
            protected override void OnPreRender(EventArgs e)
            {
                if (ViewState["DetailsViewMode"] != null)
                {
                    //change the mode of the DetailsView
                    dvTest.ChangeMode((DetailsViewMode)ViewState["DetailsViewMode"]);
                    
                    //Bind the details view to a source
                    //This is my own custom class but this is where you yould put
                    //DetailsView.Datasource = <source>
                    //DetailsView.DataBind()
                    Utilities.BindCompositeControl(dvTest, NadController.GetCapability(19));
                }
    
                base.OnPreRender(e);
            }
    
            protected void Page_Load(object sender, EventArgs e)
            {
            }
    
            //Must handle ModeChanging event or you'll get a run time error when binding DetailsView programatically
            protected void dvTest_ModeChanging(object sender, DetailsViewModeEventArgs e)
            { 
            }
    
            //Handles button clicks from the DetailsView control
            protected void dvTest_OnItemCommand(object sender, DetailsViewCommandEventArgs e)
            {
                ViewState["DetailsViewMode"] = GetDetailsViewMode(e.CommandName);
            }
    
          
    
            protected DetailsViewMode GetDetailsViewMode(string mode)
            {
                switch (mode)
                {
                    case Constants.Edit:
                        return DetailsViewMode.Edit;
                    case Constants.Insert:
                        return DetailsViewMode.Insert;
                    default:
                        return DetailsViewMode.ReadOnly;
                }
            }
        }
