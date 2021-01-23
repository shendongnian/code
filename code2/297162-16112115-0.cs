    foreach (string pic in pics)
    {
        if (string.IsNullOrEmpty(pic))
            continue;
    
        string first = pic.Substring(0, 1);
        Color color;
    
        switch (first.ToLower())
        {
            case "a":
                color = Colors.Green;
                break;
            case "b":
                color = Colors.Red;
                break;
            default:
                color = Colors.Black;
        }
    
        ListBoxItem item = new ListBoxItem() {
            Content = pic,
            Foreground = new SolidColorBrush(color)
        };
    
        lbxFileList.Items.Add(pic);
    }
