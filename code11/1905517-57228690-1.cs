    public partial class UserControl1 : UserControl
	{
		public static readonly DependencyProperty InnerButtonProperty = DependencyProperty.Register("InnerButton", typeof(Button), typeof(UserControl1));
		public Button InnerButton
		{
			get { return (Button)GetValue(InnerButtonProperty); }
			set { SetValue(InnerButtonProperty, value); }
		}
		public UserControl1()
		{
			InitializeComponent();
			InnerButton = innerButton;
		}
	}
