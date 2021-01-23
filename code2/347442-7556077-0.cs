    public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
    {
    var cell = tableView.DequeueReusableCell("reuseThis");
    if(cell == null)
    {
    cell = new UITableViewCell(UITableViewCellStyle.Default, "reuseThis");
    }
    
    cell.TextLabel.Text = Convert.ToChar(dash.oneToHundred[indexPath.Row]).ToString();
    
    var button = UIButton.FromType(UIButtonType.RoundedRect);
    button.Frame = new System.Drawing.RectangleF(40f, 0f, 280f, 40f);
    button.SetTitle(dash.oneToHundred[indexPath.Row].ToString(),UIControlState.Normal);
    button.AddTarget (this, new Selector ("MySelector"), UIControlEvent.TouchDown);
    button.Tag = indexPath.Row;
    cell.ContentView.AddSubview(button);
    
    return cell;
    }
    
    [Export ("MySelector")]
    void ButtonEventHere (UIButton button)
    {
    
    Console.WriteLine ("Hello! - Button clicked = " + button.Tag );
    Console.WriteLine ( Convert.ToChar(dash.oneToHundred[button.Tag]).ToString() );
    }
    
     
