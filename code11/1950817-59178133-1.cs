    //XAML code
    <?xml version="1.0" encoding="utf-8" ?>
    <ContentPage xmlns="http://xamarin.com/schemas/2014/forms"
                 xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
                 xmlns:d="http://xamarin.com/schemas/2014/forms/design"
                 xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
                 mc:Ignorable="d"
                 x:Class="Demo.MainPage">
    
        <StackLayout Margin="20,35,20,20">
            <Entry x:Name="nameEntry" Placeholder="Enter name" />
            <Label Text="Math"/>
            <Switch x:Name="Math" Toggled="Switcher_Toggled" ClassId="Math" />
            <Label Text="History"/>
            <Switch x:Name="History" Toggled="Switcher_Toggled" ClassId="History"/>
            <Button x:Name="StartButton" Clicked="OnStartButtonClicked" Text="Start Quiz"/>
        </StackLayout>
    </ContentPage>
    //XAML code behind logic.
    public partial class MainPage : ContentPage
    {
        public List<string> SelectedCategories { get; set; }
        public MainPage()
        {
            InitializeComponent();
            this.SelectedCategories = new List<string>();
        }
        private void OnStartButtonClicked(object sender, EventArgs e)
        {
            if (this.Math.IsToggled || this.History.IsToggled)
            {
                this.DisplayAlert("Alert", "Quiz Started..!", "OK");
            }
        }
        private void Switcher_Toggled(object sender, ToggledEventArgs e)
        {
            var switchItem = (Switch)sender;
            if (!e.Value)
            {
                SelectedCategories.Remove(switchItem.ClassId);
            }
            else
            {
                SelectedCategories.Add(switchItem.ClassId);
            }
        }
    }
