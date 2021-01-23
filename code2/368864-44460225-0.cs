    private void DataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
            {
                if(YourColumn == typeof(DateTime))
                {
                    e.Column.ClipboardContentBinding.StringFormat = "d";
                }
            }
