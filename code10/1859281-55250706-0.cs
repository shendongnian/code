        public MainPage()
        {
            InitializeComponent();
            MyEntry.TextChanged+= MyEntry_TextChanged;
        }
        void MyEntry_TextChanged(object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            if (MyEntry.Text.StartsWith("0"))
                MyEntry.Text = e.OldTextValue;
        }
