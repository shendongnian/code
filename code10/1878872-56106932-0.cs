    public partial class ViewController : UIViewController
    {
        public ViewController(IntPtr handle) : base(handle)
        {
        }
        int inputCount = 0;
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
            UITextField textF = new UITextField();
            textF.BorderStyle = UITextBorderStyle.Line;
            textF.Frame = new CoreGraphics.CGRect(100, 100, 100, 50);
            View.Add(textF);
            var notification = UITextField.Notifications.ObserveTextFieldTextDidChange((sender, args) => {
                /* Access strongly typed args */
                Console.WriteLine("Notification: {0}", args.Notification);
                inputCount++;
                PerformSelector(new ObjCRuntime.Selector("SearchCodes:"), (NSString)(inputCount.ToString()), 2);
            });
        }
        [Export("SearchCodes:")]
        public void SearchCodes(NSString count)
        {
            if (Convert.ToInt32(count) == this.inputCount)
            {
                Console.WriteLine("start search");
                UIAlertView alertV = new UIAlertView("start search", "",null,"ok");
                alertV.Show();
            }
        }
    }
