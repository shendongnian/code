       public MainPage()
        {
            InitializeComponent();
            MessagingCenter.Subscribe<List<string>>(this, "MyMessage", (expense) =>
            {
                List<string> mylist= expense as List<string>;
                string allText= "";
                foreach (string item in mylist)
                {
                    allText += item+"  ";
                }
                editorSms.Text = allText;
            });
           
        
        }
      
        private void Button_Clicked(object sender, EventArgs e)
        {
            Xamarin.Forms.DependencyService.Get<ISmsReader>().GetSmsInbox();
        }
 
