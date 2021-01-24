    public partial class SecondVC : UIViewController
    {
        int[] values;
        public SecondVC(int[] values) : base("SecondVC", null)
        {
            this.values = values;
        }
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
        }
        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
