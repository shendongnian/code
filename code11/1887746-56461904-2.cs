    public sealed partial class MainPage : Page
    {
        private readonly ObservableCollection<string> _persons = new ObservableCollection<string>();
        public MainPage()
        {
            this.InitializeComponent();
            listBox.ItemsSource = _persons;
        }
        private void RegistrerDebtor(object sender, RoutedEventArgs e)
        {
            Person person = new Person();
            person.Identification = TxtIdentification.Text;
            person.Name = TxtName.Text;
            person.LastName = TxtLastName.Text;
            person.Address = TxtAddress.Text;
            person.Phone = TxtPhone.Text;
            person.Email = TxtMail.Text;
            person.Latitude = TxtLatitude.Text;
            person.OriLat = CbxOrientationLat.Text;
            person.Longitude = TxtLongitude.Text;
            person.OriLon = CbxOrientationLon.Text;
            string json = JsonConvert.SerializeObject(person, Formatting.Indented);
            _persons.Add(json);
        }
    }
