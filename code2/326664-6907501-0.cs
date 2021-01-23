    text2 = new DataGridTextColumn();
    bind = new System.Windows.Data.Binding("ValueList");
    bind.ConverterParameter = i;
    bind.Converter = new IndexConverter();             
    text2.Binding = bind;
    text2.Header = "Header";
    text2.MaxWidth = 100;
    ....           
    datagrid1.Columns.Add(text2);
