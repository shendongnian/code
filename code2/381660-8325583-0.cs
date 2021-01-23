    foreach(MyObject o in MyList)
    {
        MenuItem item = new MenuItem();
        item.Header = o.Name;
        item.Tag = o;
        item.Click += MenuItem_Click;
        menu.Items.add(item);
    }
    
