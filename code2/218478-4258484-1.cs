            for (int i = 0; i < 100; i++)
            {
                DataGridTemplateColumn column = new DataGridTemplateColumn();
                column.CellTemplate = (DataTemplate)XamlReader.Parse(
                    "<DataTemplate xmlns='http://schemas.microsoft.com/winfx/2006/xaml/presentation'>" +
                        "<TextBlock DataContext='{Binding [" + i + "]}' Text='{Binding Text}' Background='{Binding Background}' Foreground='{Binding Foreground}'/>" +
                    "</DataTemplate>");
                column.Header = "Column " + i;
                dg.Columns.Add(column);
            }
