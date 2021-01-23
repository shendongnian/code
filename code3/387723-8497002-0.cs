	public class MyStyledStringElement {
		
		public void SetValueAndUpdate (string value)
		{
			Value = value;
			if (GetContainerTableView () != null) {
				var root = GetImmediateRootElement ();
				root.Reload (this, UITableViewRowAnimation.Fade);
			}
		}
	}
