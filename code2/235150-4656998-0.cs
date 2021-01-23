    protected void Page_Load(object sender, EventArgs e)
    {
        String[] d1 = { "1", "2", "3" };
        String[] d2 = { "4", "5", "6", "7" };
        ListView1.DataSource = d1;
        ListView1.DataBind();
        ListView2.DataSource = d2;
        ListView2.DataBind();
    }
    
    protected void lv_command(object sender, ListViewCommandEventArgs e)
    {
      int i = 0;
    }
