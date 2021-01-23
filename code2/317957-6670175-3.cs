    protected void submitButton_Click(object sender, EventArgs e)
        {
            string textLines;
            string[] textLine;
    
            textLines = scannedCode.Text;
    
            textLine = textLines.Split(Environment.NewLine.ToArray(), StringSplitOptions.RemoveEmptyEntries);
    
            DataSet ds = null;
            Database db = DatabaseFactory.CreateDatabase("ConnectionString");
            DataSet ds2 = null; 
            Database db2 = DatabaseFactory.CreateDatabase("ConnectionString");
    
    		DataTable dt = new DataTable();
    		///...Add known columns here
            foreach (string s in textLine)
            {
                try
                {
                    DbCommand command2 = db.GetStoredProcCommand("sel_InfoByID_p");
                    db2.AddInParameter(command2, "@pGuid", DbType.String, s);
                    DataRow myNewRow = db2.ExecuteDataSet(command2).tables[0].rows[0];
    				dt.Rows.Add(myNewRow);
    				
                 }
    
                catch (Exception ex)
                {
    
                }
            }
    
    	
                   DataGrid1.DataSource = dt;
                    DataBind();
    
    
        }
