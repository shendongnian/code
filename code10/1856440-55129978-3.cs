        public static DataTable CsvToDataTable(string csv)
    	{
    		DataTable dt = new DataTable();
    		string[] lines = csv.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
    		Regex onlyDeimiterComma = new Regex(",(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))");
    		
    		for (int i = 0; i < lines.Length; i++)
    		{
    			DataRow row = dt.NewRow();
    			string[] cells = onlyDeimiterComma.Split(lines[i]);
    			
    			for (int j = 0; j < cells.Length; j++)
    			{
    				if (i == 0)
    				{ 
    					if (j == 0)
    					{
    						dt.Columns.Add(cells[j], typeof(DateTime));
    					}
    					else
    					{
    						dt.Columns.Add(cells[j]);
    					}					
    				}
    				else
    				{
    					row[j] = cells[j];
    				}
    			}
    			
    			dt.Rows.Add(row);
    		}
    
    		return dt;
    	}
