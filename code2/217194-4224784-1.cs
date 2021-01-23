     //Dummy object for illustrative purposes only.
    [Serializable]
    public class bllUsers
    {
        public int Id { get; set; }
        public bool isDefault { get; set; }
        public string Name { get; set; }
        public bllUsers(int _id, bool _isDefault, string _name)
        {
            this.Id = _id;
            this.isDefault = _isDefault;
            this.Name = _name;
        }
    }
    protected List<bllUsers> lstUsers{
        get
        {
            if (ViewState["lstUsers"] == null){
                ViewState["lstUsers"] = buildUserList();
            }
            return (List<bllUsers>)ViewState["lstUsers"];
            }
            set{
                ViewState["lstUsers"] = value;
            }
        }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            buildGui();
        }
    }
    private List<bllUsers> buildUserList(){
        lstUsers = new List<bllUsers>();
        lstUsers.Add(new bllUsers(1, false, "Joe Bloggs"));
        lstUsers.Add(new bllUsers(2, true, "Charlie Brown"));
        lstUsers.Add(new bllUsers(3, true, "Barack Obama"));
        
        return lstUsers;
    }
    private void buildGui()
    {
        rpt1.DataSource = lstUsers;
            rpt1.DataBind();
    }
    protected void rpt1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            bllUsers obj = (bllUsers)e.Item.DataItem;//this is the actual bllUser the row is being bound to.
            //Set the labels
            ((Label)e.Item.FindControl("ldefault")).Visible = obj.isDefault;
            ((Button)e.Item.FindControl("btnMakeDefault")).Visible = ! obj.isDefault;
            //Or use a more readable if/else if you want:
            if (obj.isDefault)
            {
                //show/hide    
            }
            else
            {
                //set visible/invisible
            }
        }
    }
