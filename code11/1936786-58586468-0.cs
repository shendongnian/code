    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            var layout = new StackLayout { Padding = new Thickness(5, 10) };
            var label = new Label { Text = "Hello world" };
            var image = new Image
            {
                Source = ImageSource.FromUri(new Uri("https://s2.ax1x.com/2019/10/28/K6KUo9.png")),
                BackgroundColor = Color.Accent
            };
            layout.Children.Add(label);
            layout.Children.Add(image);
            Content = layout;
        }
    }
