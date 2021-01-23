public void test()
{
    DataGridView dataGridView = new DataGridView();
    dataGridView.Columns.Add("Col1", "Col1");
    dataGridView.Columns.Add("Col2", "Col2");
    dataGridView.Columns.Add("Col3", "Col3");
    dataGridView.Rows.Add(new object[] { 'Á', 2, 3 });
    dataGridView.Rows.Add(new object[] { 'Ä', 2, 3 });
    dataGridView.Rows.Add(new object[] { 'A', 2, 3 });
    dataGridView.Rows.Add(new object[] { 'Ö', 2, 3 });
    dataGridView.Rows.Add(new object[] { 'O', 2, 3 });
    dataGridView.Rows.Add(new object[] { 'Z', 2, 3 });
    
    dataGridView.Sort(dataGridView.Columns[0], ListSortDirection.Ascending);
    foreach(DataGridViewRow row in dataGridView.Rows)
    {
        foreach(DataGridViewColumn column in dataGridView.Columns)
        {
            Console.Write(row.Cells[column.Name].Value);
            Console.Write(" ");
        }
        Console.WriteLine();
    }
}
