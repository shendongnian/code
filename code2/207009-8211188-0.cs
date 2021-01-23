    DataTemplate mycolumnDataTemplate = null;
    var dataTemplateStream = new SomeClass().GetType().Assembly.GetManifestResourceStream("Some.Namespace.SomeReosurceName.xaml");
    string dataTemplateString = new System.IO.StreamReader(dataTemplateStream).ReadToEnd();
    dataTemplateString = dataTemplateString.Replace("[0]", browserColumn.ColumnName);
    mycolumnDataTemplate = XamlReader.Load(dataTemplateString) as DataTemplate;
