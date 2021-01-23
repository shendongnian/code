    public override void ViewDidLoad ()
    		{
    			base.ViewDidLoad ();
    			
    			var ad = new GADBannerView(new RectangleF(new PointF(0,0), GADBannerView.GAD_SIZE_300x250))
    			{
    				AdUnitID = "Use Your AdMob Id here",
    				RootViewController = this
    				
    			};
    			
    			ad.DidReceiveAd += delegate 
    			{
    				this.View.AddSubview(ad);
    				Console.WriteLine("AD Received");
    			};
    			
    			ad.DidFailToReceiveAdWithError += delegate(object sender, GADBannerViewDidFailWithErrorEventArgs e) {
    				Console.WriteLine(e.Error);
    			};
    			
    			ad.WillPresentScreen += delegate {
    				Console.WriteLine("showing new screen");
    			};
    			
    			ad.WillLeaveApplication += delegate {
    				Console.WriteLine("I will leave application");
    			};
    			
    			ad.WillDismissScreen += delegate {
    				Console.WriteLine("Dismissing opened screen");
    			};
    			
    			Console.Write("Requesting Ad");
    			ad.LoadRequest(new GADRequest());
    }
