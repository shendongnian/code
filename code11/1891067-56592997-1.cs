    public override UIView GetViewForHeader(UITableView tableView, nint section)
    {
        //var header = tableView.DequeueReusableHeaderFooterView("TestHeaderIdentifier");
        //if (header == null)
        //    header = new UITableViewHeaderFooterView(new NSString("TestHeaderIdentifier"));
        //header.TextLabel.Text = "Section " + section;
        //header.TextLabel.TextColor = UIColor.Red;
        //header.ContentView.BackgroundColor = UIColor.FromRGB(124, 255, 190);
        ////.. Other customizations
        //return header;
        UIView view = new UIView();
        view.Frame = new CoreGraphics.CGRect(0,100,200,50);
        UILabel label = new UILabel();
        label.Frame = view.Bounds;
        label.Text = "test";
        label.TextColor = UIColor.Red;
        view.Add(label);
        return view;
    }
