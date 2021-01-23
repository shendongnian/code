     this.SetToolbarItems( new UIBarButtonItem[] {
				new UIBarButtonItem(UIBarButtonSystemItem.Refresh, (s,e) =>      {
					Console.WriteLine("Refresh clicked");
				})
					
				, new UIBarButtonItem(UIBarButtonSystemItem.FlexibleSpace) { Width = 50 }
				, new UIBarButtonItem(UIImage.FromBundle
				                      ("wrench_support_white.png"), UIBarButtonItemStyle.Plain, (sender,args) => {
					Console.WriteLine("Support clicked");
				})
			}, false);
