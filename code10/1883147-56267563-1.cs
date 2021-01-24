    public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
    
            UITableView table = new UITableView(View.Bounds); // defaults to Plain style
            string[] tableItems = new string[] { "Vegetables", "Fruits", "Flower Buds", "Legumes", "Bulbs", "Tubers" };
    
            TableSource s = new TableSource(tableItems);
            table.Source = s;
            Add(table);
    
    
            //get the reference 
    
            UILabel myLabel = s.testLabel;
            //update here.
        }
