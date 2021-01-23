    protected void Page_Load(object sender, EventArgs e)
    {
        Dictionary<string, object> dic = new Dictionary<string, object>();
        dic.Add("key1", new { Color = "Red", Age = 15 });
        dic.Add("key2", new { Color = "Green", Age = 25 });
        
        Accordion1.DataSource = dic;
        Accordion1.DataBind(); 
    }
