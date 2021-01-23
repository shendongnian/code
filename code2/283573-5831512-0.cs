    var dataGrid = dataGridQuestions;
    
    int i = 1;
    foreach (var parameter in QuestionParameters)
    {
        var binding = new Binding("qp" + (i++).ToString());
        binding.Mode = BindingMode.OneWay;
        var column = DataGridTextColumn() { Binding = binding, Header=parameter.Value };
        dataGrid.Columns.Add(column);
    }
