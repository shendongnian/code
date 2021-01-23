    public partial class ChildDDL : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
                return;
    
            ddlCity.Items.Add(new ListItem("Select One", "0"));
            ddlCity.Items.Add(new ListItem("City 1", "1"));
            ddlCity.Items.Add(new ListItem("City 2", "2"));
            ddlCity.Items.Add(new ListItem("City 3", "3"));
    
            List<State> lstState = new List<State>();
            lstState.Add(new State() { StateID = 1, StateName = "State 1", CityID = 1 });
            lstState.Add(new State() { StateID = 2, StateName = "State 2", CityID = 1 });
            lstState.Add(new State() { StateID = 3, StateName = "State 3", CityID = 1 });
            lstState.Add(new State() { StateID = 4, StateName = "State 4", CityID = 2 });
            lstState.Add(new State() { StateID = 5, StateName = "State 5", CityID = 2 });
            lstState.Add(new State() { StateID = 6, StateName = "State 6", CityID = 2 });
            lstState.Add(new State() { StateID = 7, StateName = "State 7", CityID = 3 });
            lstState.Add(new State() { StateID = 8, StateName = "State 8", CityID = 3 });
    
            Session["lstState"] = lstState;
        }
    
        protected void ddlCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<State> lstState = (List<State>)Session["lstState"];
    
            ddlState.DataSource = lstState
                .Where(state => state.CityID == Convert.ToInt32(ddlCity.SelectedValue)); ;
            ddlState.DataTextField = "StateName";
            ddlState.DataValueField = "StateID";
            ddlState.DataBind();
        }
    
        public class State
        {
            public int StateID { get; set; }
            public string StateName { get; set; }
            public int CityID { get; set; }
        }
    }
