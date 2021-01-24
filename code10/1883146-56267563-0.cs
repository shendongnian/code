    public class TableSource : UITableViewSource
    {
        public UILabel testLabel;
       
        public override UIView GetViewForHeader(UITableView tableView, nint section)
        {
            UILabel lab = new UILabel();
            lab.Text = "123";
            lab.Frame = new CGRect(0,0,100,50);
            //Get reference
            testLabel = lab;
            return lab;
        }
        public override nfloat GetHeightForHeader(UITableView tableView, nint section)
        {
            return 50;
        }
    }
