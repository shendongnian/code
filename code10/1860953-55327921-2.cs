    string a = "";  //declare it here before (outside) method not inside it
    private void datagrid_customer_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        for (int i = 0; i < datagrid_customer.Items.Count; i++)
        {
            if (Convert.ToString((datagrid_customer.SelectedCells[3].Column.GetCellContent(datagrid_customer.SelectedItem) as TextBlock).Text) == Convert.ToString((datagrid_customer.SelectedCells[1].Column.GetCellContent(datagrid_customer.Items[i]) as TextBlock).Text))
            {
                ...
                a = (b + c + d).ToString();       
            }
     }
