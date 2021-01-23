    private void DataGrid_AutoGeneratingColumn(object sender, System.Windows.Controls.DataGridAutoGeneratingColumnEventArgs e)
            {
                //your date time property
                if (e.PropertyType == typeof(System.DateTime))
                {
                    DataGridTextColumn dgtc = e.Column as DataGridTextColumn;
                    DateTimeConverter con = new DateTimeConverter();
                    (dgtc.Binding as Binding).Converter = con;
                }
            }
