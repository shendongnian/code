    <ImageButton
                BackgroundColor="#fafafa"
                BorderColor="#fafafa"
                Command="{Binding PlayCommand}"
                HeightRequest="50"
                Source="{Binding PlayImage}"
                WidthRequest="50" />
     public partial class Page4 : ContentPage
    {
        public Page4()
        {
            InitializeComponent();
            this.BindingContext = new SermonDetailViewModel();
        }
    }
    public class SermonDetailViewModel:ViewModelBase
    {
        public ICommand PlayCommand { private set; get; }
        private ImageSource _playImage;
        public ImageSource PlayImage
        {
            get { return _playImage; }
            set
            {
                _playImage = value;
                RaisePropertyChanged("PlayImage");
            }
        }
        public SermonDetailViewModel()
        {
            PlayCommand = new Command(method1);
            _playImage = "check.png";
               
        }
        private void method1()
        {
           
            PlayImage = "plu3.png";
        }
    }
