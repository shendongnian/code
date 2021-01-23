        private void ModifyTable(DataTable toModify)
        { //Add a column to sort by later. 
            DataColumn col = toModify.Columns.Add("DummySort", typeof(int));
            col.DefaultValue = 0;
        }
        private void SetDummyColumnValue(DataRow dr, int value)
        { //Mark the columns you want to sort to bring to the top. 
            //Give values bigger than 0! 
            dr["DummySort"] = value;
        }
        private DataTable GetSortedTable(DataTable modifiedTable)
        {
            //Sort by the column from bigger to smaller 
            DataView dv = new DataView(modifiedTable);
            dv.Sort = "DummySort DESC"; return dv.ToTable();
        }
