    var yourcontrol = new ProgressBar();
    // the control needs to load before it has a template.
    yourcontrol.Loaded += (sender,e) => {
        var str = new System.Text.StringBuilder();
        using (var writer = new System.IO.StringWriter(str))
            System.Windows.Markup.XamlWriter.Save(yourcontrol .Template, writer);
        System.Diagnostics.Debug.Write(str);
    };
    // add it to your main grid, or some control thats loaded on screen.
    gridMain.Children.Add(yourcontrol);
    
