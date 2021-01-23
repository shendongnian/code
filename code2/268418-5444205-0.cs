            private void ProductsList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //moves items from top grid to bottom grid
            OrderContents.Items.Add(ProductsList.SelectedValue);   
        }
