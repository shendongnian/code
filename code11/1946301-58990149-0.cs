    <StackLayout>
        <!-- Place new controls here -->
        <ListView ItemsSource="{Binding models}" HasUnevenRows="True">
            <ListView.ItemTemplate>
                <DataTemplate>
                    <ViewCell  >
                        <StackLayout >
                            <Label Text="{Binding name}"/>
                            <Grid>
                                <Grid.RowDefinitions>
                                    <RowDefinition Height="Auto"/>
                                    <RowDefinition Height="Auto"/>
                                </Grid.RowDefinitions>
                                <Image Source="{Binding url}" Grid.Row="0" HeightRequest="60">
                                    <Image.GestureRecognizers>
                                        <TapGestureRecognizer
                Tapped="OnTapGestureRecognizerTapped"
                NumberOfTapsRequired="2" />
                                    </Image.GestureRecognizers>
                                </Image>
                                <Image Source="{Binding url1}" Grid.Row="1" HeightRequest="60"/>
                            </Grid>
                         
                        </StackLayout>
                    </ViewCell>
                </DataTemplate>
            </ListView.ItemTemplate>
        </ListView>
    </StackLayout>
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<model1> models { get; set; }
        public MainPage()
        {
            InitializeComponent();
            models = new ObservableCollection<model1>()
            {
                new model1(){name="image 1",url="image1.png",},
                new model1(){name="image 2",url="image2.png"},
                new model1(){name="image 3",url="image1.png"},
                new model1(){name="image 4",url="image2.png"},
                new model1(){name="image 5",url="image1.png"}
            };
            this.BindingContext = this;
        }
 
        private void OnTapGestureRecognizerTapped(object sender, EventArgs e)
        {
            var imageSender = (Image)sender;
 
            var grid= (Grid)imageSender.Parent;
            var stacklayout = (StackLayout)grid.Parent;
 
            var label = (Label)stacklayout.Children[0];
           
            model1 m = models.Where(o => o.name == label.Text).FirstOrDefault();
            string url = imageSender.Source.ToString();
            if(url.Contains("image1.png"))
            {
                m.url = "image2.png";
                m.url1 = "image3.png";
            }
            else if(url.Contains("image2.png"))
            {
                m.url = "image1.png";
            }
          
        }
    }
 
    public class model1:BaseViewModel
    {
        public string name { get; set; }
        private string _url;
        public string url
        {
            get { return _url; }
            set
            {
                _url = value;
                OnPropertyChanged("url");
            }
        }
        private string _url1;
        public string url1
        {
            get { return _url1; }
            set
            {
                _url1 = value;
                OnPropertyChanged("url1");
            }
        }
    }
