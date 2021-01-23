		RootElement CreateRoot ()
		{
			var btn = new UIButton ();
			btn.TouchUpInside += delegate {
				Console.WriteLine ("touch'ed");
			};
			// TODO: customize button look to your liking
			// otherwise it will look like a text label
			btn.SetTitle ("button", UIControlState.Normal);
			Section s = new Section ();
			s.HeaderView = btn;
			return new RootElement (String.Empty) {
				new Section () {
					new BooleanElement ("bool", false),
					new StringElement ("s1"),
					new StringElement ("s2"),
					},
				new Section (),
				s,
				new Section () {
					new StringElement ("s3"),
				},
			};		
		}
