            DataTable table = new DataTable();
            var myColumn = table.Columns.Cast<DataColumn>().SingleOrDefault(col => col.ColumnName == "myColumnName");
            if (myColumn != null)
            {
                // just some roww
                var tableRow = table.AsEnumerable().First();
                var myData = tableRow.Field<string>(myColumn);
                // or if above does not work
                myData = tableRow.Field<string>(table.Columns.IndexOf(myColumn));
            }
