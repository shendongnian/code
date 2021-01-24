    public class Setting
        {
    		private DataTable _dt;
            DataColumn _dclColumnDescription = new DataColumn("Description", typeof(string));
            DataColumn _dclColumnData = new DataColumn("Data", typeof(string));
    		
    		public DataTable ProcessSettingFileCMD(string filePath)
            {
                if (_dt == null)
                {
                    populateControlWithCSVData(filePath);                
                }
    		}
    		
    		private void populateControlWithCSVData(string filePath)
            {            
                _dt  = new DataTable();
                List<string> columns = new List<string>();
                
                using (var reader = new CsvFileReader(filePath))
                {
                    _dt.Columns.Add(_dclColumnDescription);
                    _dt.Columns.Add(_dclColumnData);
                    while (reader.ReadRow(columns))
                    {                    
                        _dt.Rows.Add(columns.ToArray());
                    }
                }            
            }
    	}
	
