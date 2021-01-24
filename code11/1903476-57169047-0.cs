     private void SetInitialRow()
           {
               DataTable dt = new DataTable();
               DataRow dr = null;
               dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));
               dt.Columns.Add(new DataColumn("Column1", typeof(string)));
               dt.Columns.Add(new DataColumn("Column2", typeof(string)));
               dt.Columns.Add(new DataColumn("Column3", typeof(string)));
               dr = dt.NewRow();
               dr["RowNumber"] = 1;
               dr["Column1"] = string.Empty;
               dr["Column2"] = string.Empty;
               dr["Column3"] = string.Empty;
               dt.Rows.Add(dr);
               ViewState["CurrentTable"] = dt;
        
               Gridview1.DataSource = dt;
               Gridview1.DataBind();
           }
           private void AddNewRowToGrid()
           {
               try
               {
                   int j = 8, rowIndex = 0;
           
                   DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                   DataRow drCurrentRow = null;
                 
                   if (dtCurrentTable.Rows.Count > 0)
                   {
                       for (int i = 1; i <= j; i++)
                       {
                           
                           //extract the TextBox values
                         TextBox  box1 = (TextBox)Gridview1.Rows[rowIndex].Cells[1].FindControl("TextBox1");
                         TextBox  box2 = (TextBox)Gridview1.Rows[rowIndex].Cells[2].FindControl("TextBox2");
                         TextBox  box3 = (TextBox)Gridview1.Rows[rowIndex].Cells[3].FindControl("TextBox3");
        
                           drCurrentRow = dtCurrentTable.NewRow();
                           drCurrentRow["RowNumber"] = i + 1;
                          
                           dtCurrentTable.Rows[i - 1]["Column1"] = box1.Text;
                           dtCurrentTable.Rows[i - 1]["Column2"] = box2.Text;
                           dtCurrentTable.Rows[i - 1]["Column3"] = box3.Text;
                           dtCurrentTable.Rows.Add(drCurrentRow);
                       }
                      // dtCurrentTable.Rows.Add(drCurrentRow);
                       ViewState["CurrentTable"] = dtCurrentTable;
        
                       Gridview1.DataSource = dtCurrentTable;
                       Gridview1.DataBind();
                   }
               }
               catch (Exception ex)
              {
        
               }
        
           protected void Page_Load(object sender, EventArgs e)
           {
              
               if (!Page.IsPostBack)
               {
                   SetInitialRow();
               }
           }
           protected void ButtonAdd_Click(object sender, EventArgs e)
           {
               AddNewRowToGrid();
           }
