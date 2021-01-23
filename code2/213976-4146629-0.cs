    var properties = new Dictionary<string, PropertyInfo>();
    foreach (DataGridViewColumn col in dataGridView1.Columns)
    {
        properties.Add(type.GetProperty(col.Name);
    }
