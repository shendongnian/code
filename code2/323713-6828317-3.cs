	private void AddRow_Click(object sender, RoutedEventArgs e)
	{
		var data = _tabControl.Resources["data"] as XmlDataProvider;
		var dg = (sender as FrameworkElement).Tag as DataGrid; //Reference to DataGrid is stored in the Button.Tag
		var cadeiras = dg.Tag as XmlNode; //Used DataGrid.Tag to store parent node of cadeiras so a new cadeira can be added
		var newItem =  data.Document.CreateElement("Cadeira");
		Action<string,string> addProperty = (name, val) =>
			{
				var prop =  data.Document.CreateElement(name);
				prop.InnerText = val;
				newItem.AppendChild(prop);
			};
		addProperty("Activa","1");
		addProperty("Nome","Lorem Ipsum");
		addProperty("Nota","1.3");
		cadeiras.AppendChild(newItem);
	}
