    public partial class ViewController : UIViewController
    {
        public ViewController (IntPtr handle) : base (handle)
        {
        }
        public override void ViewDidLoad ()
        {
            base.ViewDidLoad ();
            // Perform any additional setup after loading the view, typically from a nib.
            UIView backView = new UIView();
            backView.BackgroundColor = UIColor.Orange;
            backView.Frame = new CoreGraphics.CGRect(0,0,300,500);
            View.Add(backView);
            UILabel topLabel = new UILabel(new CoreGraphics.CGRect(0,10,200,50));
            topLabel.BackgroundColor = UIColor.Green;
            topLabel.Text = "I am top label";
            backView.Add(topLabel);
            UITableView middleTable = new UITableView(new CoreGraphics.CGRect(0, 60, 200, 300)); 
            string[] tableItems = new string[] { "Vegetables", "Fruits", "Flower Buds", "Legumes", "Bulbs", "Tubers" };
            //you can pass the backView when create the tableView
            middleTable.Source = new TableSource(tableItems,backView);
            backView.Add(middleTable);
            UILabel bottomLabel = new UILabel(new CoreGraphics.CGRect(0, 360, 200, 50));
            bottomLabel.BackgroundColor = UIColor.SystemPinkColor;
            bottomLabel.Text = "I am bottom Label";
            backView.Add(bottomLabel);
        }
    }
    public class TableSource : UITableViewSource
    {
        UIView mybackView;
        string[] TableItems;
        string CellIdentifier = "TableCell";
        public TableSource(string[] items, UIView backView)
        {
            TableItems = items;
            mybackView = backView;
        }
        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return TableItems.Length;
        }
        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            UITableViewCell cell = tableView.DequeueReusableCell(CellIdentifier);
            string item = TableItems[indexPath.Row];
            //---- if there are no cells to reuse, create a new one
            if (cell == null)
            { cell = new UITableViewCell(UITableViewCellStyle.Default, CellIdentifier); }
            cell.TextLabel.Text = item;
            return cell;
        }
        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            UIView presentView = new UIView();
            presentView.BackgroundColor = UIColor.Blue;
            presentView.Frame = new CoreGraphics.CGRect(40,80,250,200);
            //add the presentView to the backView instead of tablview
            mybackView.Add(presentView);
        }
    }
