		class MyUISegmentedControl : UISegmentedControl {
			
			public MyUISegmentedControl (RectangleF r) : base (r) {}
			
			public override void TouchesBegan (NSSet touches, UIEvent evt)
			{
				int current = SelectedSegment;
				base.TouchesBegan (touches, evt);
				if (current == SelectedSegment)
					SendActionForControlEvents (UIControlEvent.ValueChanged);
 			}
		}
