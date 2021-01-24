    private void BackgroundWorker2_DoWork(System.Object sender, System.ComponentModel.DoWorkEventArgs e)
    {
        for (int i = 1; i <= 7; i++)
            DataTable1.Columns.Add();
        for (int i = 1; i <= 1048576; i++)
            DataTable1.Rows.Add(i);
        var col = new ObservableCollection<MyItem>();
        foreach (DataRow row in DataTable1.Rows) col.Add(new MyItem(row));
        Dispatcher.Invoke(() =>
        {
            DataGrid1.ItemsSource = col;
        });
    }
    public class MyItem
    {
        public MyItem() { }
        public MyItem(DataRow row)
        {
            int.TryParse(row[0].ToString(),out int item1);
            int.TryParse(row[1].ToString(), out int item2);
            int.TryParse(row[2].ToString(), out int item3);
            int.TryParse(row[3].ToString(), out int item4);
            int.TryParse(row[4].ToString(), out int item5);
            int.TryParse(row[5].ToString(), out int item6);
            int.TryParse(row[6].ToString(), out int item7);
        }
        public int item1 { get; set; }
        public int item2 { get; set; }
        public int item3 { get; set; }
        public int item4 { get; set; }
        public int item5 { get; set; }
        public int item6 { get; set; }
        public int item7 { get; set; }
    }
