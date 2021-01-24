    protected void Page_Load(object sender, EventArgs e)
    {
      DataTable dtblItemList = new DataTable();
      SqlCommand komut2 = new SqlCommand("SELECT clubid,club_name FROM kulupler", 
                          baglan.Baglanma());
      SqlDataReader reader  = komut2.ExecuteReader();
      using (SqlDataReader dtr = DataExecutor.GetSqlDataReader(komut2, 
                                                        CommandBehavior.Default))
                                {
                                    dtblItemList.Load(reader);
                                }      
      DDLProduct.DataSource = dtblItemList;
      DDLProduct.DataValueField = "clubid";
      DDLProduct.DataTextField = "club_name";
      DDLProduct.DataBind();
    }
