		public static Random rand = new Random();
		public View()
		{
			InitializeComponent();
			CompositionTarget.Rendering += CompositionTarget_Rendering;
		}
		void CompositionTarget_Rendering(object sender, System.EventArgs e)
		{
			double newLeft = rand.Next(0, 640);
			double newTop = rand.Next(0, 480);
			theEllipse.SetValue(Canvas.LeftProperty,newLeft);
			theEllipse.SetValue(Canvas.TopProperty, newTop);
		}
