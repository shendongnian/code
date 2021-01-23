    public static  void PerformAutoSize(this DataGridViewColumn col)
    {
        var originalSizeMode = col.AutoSizeMode;
        col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        var width = col.Width;
        col.AutoSizeMode = originalSizeMode;
        col.Width = width;
    }
