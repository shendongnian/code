        ListItemCollection x = new ListItemCollection();
        x.Add(new ListItem() { Text = "test1" });
        var y = new ListItem() { Text = "test2" };
        x.Add(y);
        Debug.WriteLine(x[0].Text);
        Debug.WriteLine(y.Text);
