    public MainPage()
    {
       InitializeComponent();
         
       MessagingCenter.Subscribe<Object>(this, "Ok_Clicked", (sender)=> {
          picker.Unfocus();
          DisplayAlert("Title", "Ok has been clicked", "cancel");
          //do something you want
       });
       MessagingCenter.Subscribe<Object>(this, "Cancel_Clicked", (sender) => {
               
           picker.Unfocus();
           DisplayAlert("Title", "Cancel has been clicked", "cancel");
           //do something you want
         });
     }
