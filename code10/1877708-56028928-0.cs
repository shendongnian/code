    var columns = table.Columns.Cast<DataColumn>();
    var source = new AutoCompleteStringCollection();
    source.AddRange(columns.Select(x => x.ColumnName).ToArray());
    textBox1.AutoCompleteCustomSource = source;
    textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
    textBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
