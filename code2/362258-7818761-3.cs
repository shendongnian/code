    if (!IsPostBack)
    {
         List<object[]> list = new List<object[]>();
         list.Add(new object[] {11,22 });
         list.Add(new object[] { 21, 32 });
         GridView1.DataSource = list;
         GridView1.DataBind();
    }
