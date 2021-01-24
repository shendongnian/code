            DataTable csvTable = new DataTable();
            using (var reader = new StreamReader("path\\to\\file.csv"))
            {
                using (var csv = new CsvReader(reader, true))
                {
                    csvTable.Load(csv);
                }
            }
            DataColumn newColumn = new DataColumn("FileId", typeof(System.Int32));
            newColumn.DefaultValue = 1;
            csvTable.Columns.Add(newColumn);
            using (SqlBulkCopy sbc = new SqlBulkCopy(connectionString))
            {
                sbc.WriteToServer(csvTable);
            }
