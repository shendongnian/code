    public partial class ViewController : UIViewController
    {
        QLPreviewController previewController;
        public ViewController(IntPtr handle) : base(handle)
        {
        }
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            this.AutomaticallyAdjustsScrollViewInsets = false;
            this.ExtendedLayoutIncludesOpaqueBars = false;
            this.EdgesForExtendedLayout = UIRectEdge.None;
            string path = NSBundle.MainBundle.PathForResource("myPdf.pdf","");
            var reportName = "Report name";
            previewController = new QLPreviewController();
            var url = new NSUrl(path, true);
            var _dataSource = new PreviewControllerSource(this, url, reportName);
            previewController.DataSource = _dataSource;
 
            this.NavigationController.PresentViewController(previewController, true, test);
        }
        public void test() {
                var firstChild = previewController.ChildViewControllers[0];
                if (firstChild is UINavigationController)
                {
                    var naviVc = firstChild as UINavigationController;
                    naviVc.NavigationBar.BarTintColor = UIColor.Red ;
                }
            }
    }
