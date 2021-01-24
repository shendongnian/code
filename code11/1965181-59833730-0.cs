    <ContentPage.Content>
        <StackLayout>
            <Label x:Name="label1" />
        </StackLayout>
    </ContentPage.Content>
     public  Page16()
        {
            InitializeComponent();
            MessagingCenter.Subscribe<Page16, string>(this, "Xamarin", async (sender, arg) =>
            {
                label1.Text = arg;
            });
            MessagingCenter.Send<Page16, string>(this,"Xamarin","this is test");
            
        }
