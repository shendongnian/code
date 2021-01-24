      public partial class ViewController : UIViewController
        {
            UITableView table;
    
            public ViewController (IntPtr handle) : base (handle)
            {
            }
    
            public override void ViewDidLoad ()
            {
                base.ViewDidLoad ();
                // Perform any additional setup after loading the view, typically from a nib.
    
                table = new UITableView(View.Bounds); // defaults to Plain style
                string[] tableItems = new string[] { "Vegetables", "Fruits", "Flower Buds", "Legumes", "Bulbs", "Tubers" };
                table.Source = new TableSource(tableItems);
                Add(table);
    
    
                UIView headV = new UIView();
                headV.Frame = new CoreGraphics.CGRect(0,0,100,50);
                headV.BackgroundColor = UIColor.Red;
    
                UIView footV = new UIView();
                footV.Frame = new CoreGraphics.CGRect(0, 0, 100, 50);
                footV.BackgroundColor = UIColor.Green;
    
                table.TableHeaderView = headV;
                table.TableFooterView = footV;
            }
    
            public override void DidReceiveMemoryWarning ()
            {
                base.DidReceiveMemoryWarning ();
                // Release any cached data, images, etc that aren't in use.
            }
        }
    
        public class TableSource : UITableViewSource
        {
    
            string[] TableItems;
            string CellIdentifier = "TableCell";
    
            public TableSource(string[] items)
            {
                TableItems = items;
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
        }
