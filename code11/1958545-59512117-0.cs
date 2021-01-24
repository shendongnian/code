        private string status = string.Empty;
        public MainPage(string Status)
        {
            InitializeComponent();
            status = Status;
            SizeChanged += (s, a) =>
            {
                txtMailSent.TranslateTo(0, -txtMailSent.Height, 1, Easing.Linear);
            };
        }
        protected async  override void OnAppearing()
        {
            if (status == "Mail sent")
            {
                await txtMailSent.TranslateTo(0, 0, 4000, Easing.Linear);
                await Task.Delay(200);
                await txtMailSent.TranslateTo(0, -txtMailSent.Height, 4000, Easing.Linear);
            }
        }
