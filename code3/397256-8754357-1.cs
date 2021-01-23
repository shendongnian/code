	public class KeyDownTrigger : TriggerBase<TextBox>
	{
		public Key Key { get; set; }
		protected override void OnAttached()
		{
			base.OnAttached();
			AssociatedObject.PreviewKeyDown += new System.Windows.Input.KeyEventHandler(AssociatedObject_PreviewKeyDown);
		}
		protected override void OnDetaching()
		{
			base.OnDetaching();
			AssociatedObject.PreviewKeyDown -= AssociatedObject_PreviewKeyDown;
		}
		void AssociatedObject_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
		{
			if (e.Key == Key)
			{
				InvokeActions(null);
			}
		}
	}
