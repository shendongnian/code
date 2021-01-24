    public partial class MaqueText : ContentPage
	{
        private bool Execute { get; set; }
        public MaqueText ()
		{
			InitializeComponent ();
            Label1.Text = "This is to simulate a really long sentence for testing purposes";
            Label1.HorizontalOptions = LayoutOptions.Start;
            Label1.VerticalTextAlignment = TextAlignment.Center;
            Label1.LineBreakMode = LineBreakMode.NoWrap;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            Execute = true;
            Device.StartTimer(TimeSpan.FromMilliseconds(50), () =>
            {
                Label1.TranslationX += 5f;
                if (Math.Abs(Label1.TranslationX) > Width)
                {
                    Label1.TranslationX = 0;
                }
                return Execute;
            });
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            Execute = false;
        }
    }
