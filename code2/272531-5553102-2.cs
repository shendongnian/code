	public partial class TextBoxesView : UserControl
	{
		public TextBoxesView()
		{
			InitializeComponent();
			this.A = new A();
			this.DataContext = this;
			BindingOperations.SetBinding(this, TextBoxesView.MyPropertyProperty, new Binding("A.B"));
		}
		private void Button_Click(object sender, RoutedEventArgs e)
		{
			this.A.B.C = DateTime.Now.ToString();
		}
		public A A
		{
			get;
			private set;
		}
		public B MyProperty
		{
			get
			{
				return (B)this.GetValue(TextBoxesView.MyPropertyProperty);
			}
			set
			{
				this.SetValue(TextBoxesView.MyPropertyProperty, value);
			}
		}
		public static readonly DependencyProperty MyPropertyProperty =
			DependencyProperty.Register("MyProperty",
				typeof(B),
				typeof(TextBoxesView),
				new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.None, (d, e) => {  }));
	}
