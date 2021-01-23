    public class Data
        {
            public string Text { get; set; }
            public override int GetHashCode()
            {
                return Text.GetHashCode();
            }
            public override bool Equals(object obj)
            {
                return GetHashCode() == obj.GetHashCode();
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Data> list1 = new List<Data >()
                {
                     new Data() { Text="One"},
                     new Data() { Text="Two"},
                     new Data() { Text="Three"},
                };
                List<Data> list2 = new List<Data>();
                Session["list1"] = list1;
                Session["list2"] = list2;
    
                DataList1.DataSource = Session["list1"];
                DataList1.DataBind();
    
                DataList2.DataSource = Session["list2"];
                DataList2.DataBind();
            }
        }
        protected void PerformMove(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "cmd")
            {
                List<Data> list1 = Session["list1"] as List<Data>;
                List<Data> list2 = Session["list2"] as List<Data>;
    
                list1.Remove(new Data() { Text=e.CommandArgument.ToString() });
                list2.Add(new Data() { Text = e.CommandArgument.ToString() });
                DataList1.DataSource = Session["list1"];
                DataList1.DataBind();
    
                DataList2.DataSource = Session["list2"];
                DataList2.DataBind();
            }
        }
