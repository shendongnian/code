        private const int MaxRows = 3; //Configure how many Rows in the table
        private const int NumColsPerElement = 2; //Configure how many columns per element
        
        static System.Data.DataTable BuildTabularTableElements(List<DataElement> elements)
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            int columnCount = (((elements.Count + MaxRows - 1) / MaxRows)) * NumColsPerElement;          
            
            for (int x = 0; x < columnCount; x++) //Add enough columns
                dt.Columns.Add();
            
            for (int x = 0; x < Math.Min(MaxRows, elements.Count); x++) //Add enough rows
                dt.Rows.Add();
            for (int x = 0; x < elements.Count; x++)
            {
                int curCol = (x / MaxRows) * NumColsPerElement; //Determine the current col/row
                int curRow = x % MaxRows;
                
                dt.Rows[curRow][curCol] = elements[x]First you need a.Value1; //Place the data in the correct row/column
                dt.Rows[curRow][curCol+1] = elements[x].Value2;
            }
            return dt;
        }
