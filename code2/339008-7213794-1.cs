    public class Data
        {
            public int No { get; set; }
            public string Name { get; set; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Data> list = new List<Data>()
                {
                     new Data(){ No=1, Name="A"},
                     new Data(){ No=2, Name="B"},
                     new Data(){ No=3, Name="C"}
                };
                GridView1.DataSource = list;
                GridView1.DataBind();
            }
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Del")
            {
                Response.Write("Delete : " + e.CommandArgument);
            }
            else
                if (e.CommandName == "Show")
                {
                    Response.Write("Show : " + e.CommandArgument);
                }
    
        }
