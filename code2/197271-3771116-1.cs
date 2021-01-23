    protected void Page_Load(object sender, EventArgs e)
            {
                if(!IsPostBack)
                {
                    var dt = new DataTable();
                    dt.Columns.Add("Users");
    
                    const string str = "User {0}";
                    for(var i=1;i<=10;i++)
                    {
                        //var r = dt.NewRow();
                        //r.ItemArray=new object[]{string.Format(str,i)};
                        dt.Rows.Add(new object[] {string.Format(str, i)});
                    }
                    list1.DataSource = dt;
                    list1.DataTextField = "Users";
                    list1.DataBind();
                }
            }
    
            protected void btn_Click(object sender, EventArgs e)
            {
                var s = list1.Items.Cast<ListItem>()
                       .Where(item => item.Selected)
                       .Aggregate("", (current, item) => current + (item.Text + ", "));
                lbl.Text = s.TrimEnd(new[] {',', ' '});
            }
