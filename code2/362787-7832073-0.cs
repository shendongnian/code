    public class Demo
        {
            public string Dept { get; set; }
            public string Email { get; set; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Demo> list = new List<Demo>()
                {
                        new Demo() { Dept="A", Email="a@a.com" },
                        new Demo() { Dept="B", Email="b@b.com" },
                };
        
                GridView1.DataSource = list;
                GridView1.DataBind();
            }
        
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "cmd")
            {
                GridViewRow row = (e.CommandSource as LinkButton).NamingContainer as GridViewRow;
                Label email = row.Cells[1].FindControl("email") as Label;
                email.Visible = true;
        
            }
        }
