    List<MyItem> items = new List<MyItem>();
    dataGridView1.Rows.OfType<DataGridViewRow>().ToList<DataGridViewRow>().ForEach(
                    row =>
                    {
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            //I've assumed imaginary properties ColName and ColValue in MyItem class
                            items.Add(new MyItem { ColName = cell.OwningColumn.Name, ColValue = cell.Value });
                        }
                    });
