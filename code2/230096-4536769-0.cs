            DataTable dataTable = new DataTable();
            DataColumn dc = new DataColumn("FieldName");
            dataTable.Columns.Add(dc);
            DataRow dr = dataTable.NewRow();
            dr[0] = "D'sulja";
            dataTable.Rows.Add(dr);
            string input = "D'sulja";
            
            var result = from item in dataTable.AsEnumerable()
                         where item.Field<string>("FieldName") == input select item;
