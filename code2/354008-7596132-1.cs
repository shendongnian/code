	for (int i=0; i<menus.Count(); i++)
	{
		ApplicationBarIconButton button = new ApplicationBarIconButton();
		button.IconUri = new Uri(menus.ElementAt(i).Element("ImageUrl").Value.Trim(),UriKind.Relative);
		button.Text = menus.ElementAt(i).Element("Title").Value.Trim();
		var i2 = i; //Thanks to `ajmccall` - I forgot this.
		button.Click += (s, e) =>
		{
			// the variable `i2` is accessible now.
		};
		ApplicationBar.Buttons.Add(button);
	}
