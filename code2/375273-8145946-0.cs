    if(!Page.IsPostBack){
      GridView1.DataSource = your_DataSet_or_DataTable_or_Anything;
      GirdView1.DataBind();
      if(your_DataSet_or_DataTable_or_Anything == null){
        btnExpExcel.Visible = false;
      }
    }
^^
