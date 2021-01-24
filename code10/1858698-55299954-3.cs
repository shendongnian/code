        private void Button_Click(object sender, RoutedEventArgs e)
        {
            foreach (DataGridTemplateColumn item in MyDataGrid.Columns)
            {
                if (item.Width.IsAuto)
                {
                    item.Width = new DataGridLength(item.ActualWidth, item.Width.UnitType);
                    item.Width = DataGridLength.Auto;
                }
            }
        }
