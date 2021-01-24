    public partial class PlayerDetailPage : ContentPage
    {
        public PlayerDetailPage()
        {
            InitializeComponent();
        }
        async void OnEditPlayerButtonClicked(object send, EventArgs e)
        {
            await floatingButtonEdit.ScaleTo(1.5, 500);
            await floatingButtonEdit.ScaleTo(0, 500, Easing.SpringOut);
            Player myPlayer = this.BindingContext as Player;
            await Navigation.PushAsync(new RosterEntryPage
            {
                BindingContext = myPlayer
            });
        }
    }
