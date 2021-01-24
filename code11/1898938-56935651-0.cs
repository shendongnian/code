        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems != null && e.AddedItems.Count > 0)
            {
                var dataGridItem = e.AddedItems[0] as MyDataClass;
                IDtextbox.Text = dataGridItem.Id.ToString();
                Nametextbox.Text = dataGridItem.Name.ToString();
            }
        }
