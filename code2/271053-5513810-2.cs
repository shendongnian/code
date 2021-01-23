	[ContentProperty("Items")]
	public partial class CustomComboBox : UserControl
	{
		public event RoutedEventHandler ApplyClick;
		public event RoutedEventHandler ResetClick;
		public ItemCollection Items
		{
			get { return _comboBox.Items; }
			set
			{
				_comboBox.Items.Clear();
				foreach (var item in value)
				{
					_comboBox.Items.Add(item);
				}
			}
		}
		public CustomComboBox()
		{
			InitializeComponent();
		}
		private void Button_Apply_Click(object sender, RoutedEventArgs e)
		{
			if (ApplyClick != null)
			{
				ApplyClick(sender, e);
			}
		}
		private void Button_Reset_Click(object sender, RoutedEventArgs e)
		{
			if (ResetClick != null)
			{
				ResetClick(sender, e);
			}
		}
	}
