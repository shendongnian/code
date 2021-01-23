	public partial class Window1 : Window
	{
		public Window1()
		{
			InitializeComponent();
		}
		public override void OnApplyTemplate()
		{
			base.OnApplyTemplate();
			CurrentTag = "4";
		}
		public static readonly DependencyProperty CurrentTagProperty = DependencyProperty.Register(
			"CurrentTag", typeof(string), typeof(Window1),
			new PropertyMetadata("1"));
		public string CurrentTag
		{
			get { return (string)this.GetValue(CurrentTagProperty); }
			set { this.SetValue(CurrentTagProperty, value); }
		}
	}
