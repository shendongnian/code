    public void LoadImages()
    {
        imgList.ItemsSource = XElement.Load("Images.xml")
            .Descendants("Item")
            .Select(item =>
        {
            var title = item.Element("Title").Value;
            var folder = item.Element("Image").Attribute("FolderName").Value;
            var file = item.Element("Image").Value;
            var path = Path.Combine(folder, file);
            return new Picture
            {
                Title = title,
                Img = new BitmapImage(new Uri(path, UriKind.Relative))
            };
        });
    }
