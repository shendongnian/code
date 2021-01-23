	public partial class LED : UserControl
	{
		public static readonly DependencyProperty LEDColorProperty = DependencyProperty.Register(
			"LEDColor",
			typeof(Brush),
			typeof(LED));
			
		public Brush LEDColor
		{
			get { return this.GetValue(LEDColorProperty) as Brush; }
			set { this.SetValue(LEDColorProperty, value); }
		}
		// LEDSize and LEDLabel omitted for brevity, but they're very similar to LEDColor
		public LED()
		{
			InitializeComponent();
		}
	}
