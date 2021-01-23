	public sealed class AlertView : UIAlertView
    {
        public AlertView (string title, string message,UIAlertViewDelegate del, string cancelButtonTitle, params string[] otherButtons)
			: base ()
        {
			Title = title;
			Message = message;
			Delegate = del;
			// add buttons
			CancelButtonIndex = AddButton (cancelButtonTitle);
			foreach (string s in otherButtons)
				AddButton (s);
        }
     ...
