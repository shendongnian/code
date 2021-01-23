			UIView view = new UIView (new RectangleF (0, 0, 200, 10));
			view.MultipleTouchEnabled = true;
			GlassButton gb = new GlassButton (new RectangleF (10,10,100,100));
			gb.SetTitle ("Contact", UIControlState.Normal);
			gb.Enabled = true;
			gb.Tapped += delegate {
				 Console.WriteLine ("hello");
			};
			view.AddSubview (gb);
