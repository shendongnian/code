    private void OnAutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
    {
        if (e.PropertyType == typeof(System.DateTime))
            (e.Column as DataGridTextColumn).Binding.StringFormat = "dd/mm/yy";
    }
