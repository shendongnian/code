    if (!IsPostBack)
     {
      List<object[]> list = new List<object[]>();
      list.Add(new object[] {11,22 });
      list.Add(new object[] { 21, 32 });
     
      var result = from ar in list
                   select new
                        {
                            Data1=ar[0].ToString(),
                            Data2=ar[1].ToString()
                        };
    
      GridView1.DataSource = result.ToList();
      GridView1.DataBind();
    }
