		RootElement CreateRoot ()
		{
			StringElement se = new StringElement (String.Empty);
			MyRadioElement.OnSelected += delegate(object sender, EventArgs e) {
				se.Caption = (sender as MyRadioElement).Caption;
				var root = se.GetImmediateRootElement ();
				root.Reload (se, UITableViewRowAnimation.Fade);
			};
			return new RootElement (String.Empty, new RadioGroup (0)) {
				new Section ("Dr. Who ?") {
					new MyRadioElement ("Dr. House"),
					new MyRadioElement ("Dr. Zhivago"),
					new MyRadioElement ("Dr. Moreau")
				},
				new Section ("Winner") {
					se
				}
			};
		}
