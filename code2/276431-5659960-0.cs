    void gridView_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
    {
        if (e.PropertyType == typeof(DateTime))
        {
             DataGridBoundColumn obj = e.Column as DataGridBoundColumn;
             if (obj != null && obj.Binding != null)
                  obj.Binding.StringFormat = "{0:d}";
        }
    }
