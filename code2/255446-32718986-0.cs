    private void dataGridCase_SelectionChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            foreach (var item in e.AddedCells)
            {
                var col = item.Column as DataGridColumn;
                var fc = col.GetCellContent(item.Item);
                lstTxns.Items.Add((fc as TextBlock).Text);
            }
        }
