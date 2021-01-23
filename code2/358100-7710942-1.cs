    public void Button2_Click1(object sender, EventArgs e)
    {
     if(Session["filename"]!=null)
     { 
      string filename=Session["filename"].ToString();
      DataSet ds = new DataSet();
      ds.ReadXml((Server.MapPath("~/" + filename)));
      GridView1.DataSource = ds;
      GridView1.DataBind();
    }  
