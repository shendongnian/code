      ICollection CreateDataSource() 
      {
         DataTable dt = new DataTable();
         DataRow dr;
    
         dt.Columns.Add(new DataColumn("StringValue", typeof(string)));
    
         for (int i = 0; i < 10; i++) 
         {
            dr = dt.NewRow();
            dr[0] = "Item " + i.ToString();
            dt.Rows.Add(dr);
         }
    
         DataView dv = new DataView(dt);
         return dv;
      }
    
      void Page_Load(Object sender, EventArgs e) 
      {
         if (!IsPostBack) 
         {
            DataList1.DataSource = CreateDataSource();
            DataList1.DataBind();
         }
      }
