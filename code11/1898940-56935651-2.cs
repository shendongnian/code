C#
private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
{
    if (e.AddedItems != null && e.AddedItems.Count > 0)
    {
        DataRowView row_selected = e.AddedItems[0] as DataRowView;
        if (row_selected != null)
        {
            IDtextbox.Text = row_selected["Id"].ToString();
            Nametextbox.Text = row_selected["Name"].ToString();
        }
    }
}
