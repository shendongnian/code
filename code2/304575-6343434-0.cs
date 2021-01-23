               // Create a DataTable from Linq query.       
                 IEnumerable<DataRow> query = from row in CSVDataTable.AsEnumerable()
                                                where CSVDataTable.Columns.Cast<DataColumn>().Any(col => !row.IsNull(col))
                                                select row; //returns IEnumerable<DataRow>
                 DataTable CSVDataTableWithoutEmptyRow = query.CopyToDataTable<DataRow>();
