    public partial class Page2 : ContentPage
    {
        public Page2()
        {
            InitializeComponent();
    
            MessagingCenter.Subscribe<Object>(this, "addLabelNotification", (sender) =>
            {
                // Do something whenever the "addLabelNotification" message is received
    
                Label NCounterName = new Label();
                NCounterName.Text = "counter_txt";
                Label NCounterNumber = new Label();
                NCounterNumber.Text = "0000";
    
                MainStackLayout.Children.Add(NCounterName);
                MainStackLayout.Children.Add(NCounterNumber);
    
            });
        }
    }
