	class MyDialogViewController : DialogViewController {
		
		public MyDialogViewController (RootElement root) : base (root)
		{
		}
		
		public override void LoadView ()
		{
			base.LoadView ();
			TableView.BackgroundColor = UIColor.Clear;
			UIImage background = UIImage.FromFile ("background.png");
			ParentViewController.View.BackgroundColor = UIColor.FromPatternImage (background);
	    }
	}
