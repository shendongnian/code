    public partial class _default : System.Web.UI.Page
    {
        ICollection<Company> companies = new List<Company>()
            {
                new Company(1, "company1"),
                new Company(2, "company2"),
                new Company(3, "company3")
            };
        ICollection<Project> projects = new List<Project>()
            {
                new Project(1, "project1a", 1),
                new Project(2, "project2a", 2),
                new Project(3, "project3a", 3),
                new Project(4, "project1b", 1),
                new Project(5, "project2b", 2),
                new Project(6, "project3b", 3),
            };
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                company_list.DataSource = companies;
                company_list.DataTextField = "Name";
                company_list.DataValueField = "Id";
                company_list.DataBind();
                company_list.Items.Insert(0, new System.Web.UI.WebControls.ListItem("-- Please Select Company --"));
            }
        }
        protected void company_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl = sender as DropDownList;
            Gridview1.DataSource = projects.Where(x => x.CompanyId == Int32.Parse(ddl.SelectedValue));
            Gridview1.DataBind();
        }
    }
