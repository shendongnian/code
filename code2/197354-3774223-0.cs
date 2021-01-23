    private static DataTemplate GetToolTipsDataTemplate()
        {
            XNamespace ns = "http://schemas.microsoft.com/winfx/2006/xaml/presentation";
            XNamespace x = "http://schemas.microsoft.com/winfx/2006/xaml";
            XNamespace my = "clr-namespace:C1.WPF.C1Chart;assembly=C1.WPF.C1Chart";
            XElement xDataTemplate =
                new XElement(ns + "DataTemplate",
                    new XElement(ns + "Border",
                        new XAttribute("BorderBrush", "Black"),
                        new XElement(ns + "Grid",
                            new XElement(ns + "Grid.ColumnDefinitions",
                                new XElement(ns + "ColumnDefinition"),
                                new XElement(ns + "ColumnDefinition")),
                            new XElement(ns + "Grid.RowDefinitions",
                                new XElement(ns + "RowDefinition"),
                                new XElement(ns + "RowDefinition")),
                            new XElement(ns + "TextBlock",
                                new XAttribute("Text", "X=")),
                            new XElement(ns + "TextBlock",
                                new XAttribute("Text", "{Binding Path=[XValues]}"), //, Converter={" + x +"Static " + my + "Converters.Format}, ConverterParameter=#.##}"),
                                new XAttribute("Grid.Column", "1")),
                            new XElement(ns + "TextBlock",
                                new XAttribute("Text", "Y="),
                                new XAttribute("Grid.Row", "1")),
                            new XElement(ns + "TextBlock",
                                new XAttribute("Text", "{Binding Path= [Values]}"), //, Converter={" + x +":Static " + my + ":Converters.Format}, ConverterParameter=#.##}"),
                                new XAttribute("Grid.Column", "1"),
                                new XAttribute("Grid.Row", "1"))
                                )));
            StringReader sr = new StringReader(xDataTemplate.ToString());
            XmlReader xr = XmlReader.Create(sr);
            DataTemplate dataTemplateObect = System.Windows.Markup.XamlReader.Load(xr) as DataTemplate;
            return dataTemplateObect;
        }
