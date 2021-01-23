    if (!IsPostBack)
    {
          Dictionary<string, string> data = new Dictionary<string, string>();
    
          for (int i = 0; i < 10; i++)
           data.Add("i" + i, "i" + i);    
          
           prevSubList.DataSource = data;
           prevSubList.DataBind();
    }
