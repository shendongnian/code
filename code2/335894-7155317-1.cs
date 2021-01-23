	public class TabBarController : UITabBarController
	{
		UIViewController one = new UIViewController ();
		UIViewController two = new UIViewController ();
		UIViewController three = new UIViewController ();
		
		private UIView myTabView;
			
	    public UIColor BackgroundColor { 
			get { return myTabView.BackgroundColor; }
			set { myTabView.BackgroundColor = value; }
		}		
	    public TabBarController()
 	    {
	        var frame = new RectangleF(0.0f, 0.0f, this.View.Bounds.Size.Width, 46);
	        myTabView = new UIView(frame);
	        myTabView.Alpha = 0.5f;
	        this.TabBar.InsertSubview(myTabView, 0);
			// Add tabs here, which show up correctly (on default background color)
	        ViewControllers = new UIViewController[] { one, two, three };
    	}
    }
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			TabBarController controller = new TabBarController ();
			// change background (to cyan) works before adding subview
			controller.BackgroundColor = UIColor.Cyan;
			window.AddSubview (controller.View);
			// change background (to blue) works after adding subview
			controller.BackgroundColor = UIColor.Blue;
    ...	
