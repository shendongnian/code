    //Copy Columns from Datatable1 to Datatble2 based on columns on columnList
                DataView dtView = new DataView(dataTable1);
                DataTable dataTable2= new DataTable();
                var getColumnNamesCommaSeperated = columnList.Select(x => x.columnNames).ToArray();
                dataTable2= dataTable1.Select().CopyToDataTable()
                    .DefaultView.ToTable(false, getColumnNamesCommaSeperated);
