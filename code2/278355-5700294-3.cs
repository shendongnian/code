	public partial class MyUserControl1 : UserControl
	{
		// The dependency property which will be accessible on the UserControl
		public static readonly DependencyProperty MyTextPropertyProperty =
			DependencyProperty.Register("MyTextProperty", typeof(string), typeof(MyUserControl1), new UIPropertyMetadata(String.Empty));
		public string MyTextProperty
		{
			get { return (string)GetValue(MyTextPropertyProperty); }
			set { SetValue(MyTextPropertyProperty, value); }
		}
		public MyUserControl1()
		{
			InitializeComponent();
		}
	}
