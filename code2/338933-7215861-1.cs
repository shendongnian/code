        private static DataGridTemplateColumn CreateHyperlink(string fieldName)
        {
            DataGridTemplateColumn column = new DataGridTemplateColumn();
            column.Header = "";
            string template = @"<DataTemplate
                    xmlns=""http://schemas.microsoft.com/winfx/2006/xaml/presentation"" >
                    <HyperlinkButton TargetName=""_blank"" Content=""Link""
                         NavigateUri=""{{Binding {0} Converter={{StaticResource AmazonPrefixConverter}}}}"" />
                 </DataTemplate>"; 
            column.CellTemplate = (DataTemplate)XamlReader.Load(String.Format(template, fieldName));
            column.IsReadOnly = false;
            return column;
        }
