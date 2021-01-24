    DisplayGrid.AutoGeneratingColumn += (s, e) =>
    {
        const string Xaml = "<DataTemplate xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\"><ContentControl Content=\"{{Binding {0}}}\" /></DataTemplate>";
        if (e.PropertyType == typeof(Image))
        {
            DataGridTemplateColumn tc = new DataGridTemplateColumn();
            tc.CellTemplate = System.Windows.Markup.XamlReader.Parse(string.Format(Xaml, e.PropertyName)) as DataTemplate;
            e.Column = tc;
        }
    };
