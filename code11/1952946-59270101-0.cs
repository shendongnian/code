    const string Xaml = "<ItemsControl ItemsSource=\"{Binding ListOfSubObjects}\">" +
    "                <ItemsControl.ItemsPanel>" +
    "                    <ItemsPanelTemplate>" +
    "                        <StackPanel Orientation=\"Vertical\"></StackPanel>" +
    "                    </ItemsPanelTemplate>" +
    "                </ItemsControl.ItemsPanel>" +
    "                <ItemsControl.ItemTemplate>" +
    "                    <DataTemplate>" +
    "                        <TextBlock Text=\"{Binding SubObjectName}\"/>" +
    "                    </DataTemplate>" +
    "                </ItemsControl.ItemTemplate>" +
    "            </ItemsControl>";
    ParserContext parserContext = new ParserContext();
    parserContext.XmlnsDictionary.Add("", "http://schemas.microsoft.com/winfx/2006/xaml/presentation");
    parserContext.XmlnsDictionary.Add("x", "http://schemas.microsoft.com/winfx/2006/xaml");
    ItemsControl itemsControl = XamlReader.Parse(Xaml, parserContext) as ItemsControl;
