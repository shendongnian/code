    public partial class MainPage : ContentPage
    {
        List<string> monkeyList = new List<string>();
        TestModel model = new TestModel();
        public MainPage()
        {
            InitializeComponent();
            monkeyList.Add("Baboon");
            monkeyList.Add("Capuchin Monkey");
            monkeyList.Add("Blue Monkey");
            monkeyList.Add("Squirrel Monkey");
            monkeyList.Add("Golden Lion Tamarin");
            monkeyList.Add("Howler Monkey");
            monkeyList.Add("Japanese Macaque");
            picker.ItemsSource = monkeyList;
            model.MaterialPickerTitle = "123";
            model.SelectedMaterialIndex = 2;
            BindingContext = model;
        }
        private void Button_Clicked(object sender, EventArgs e)
        {
            monkeyList.Add("Baboonww");
            model.SelectedMaterialIndex = -1;
            model.MaterialPickerTitle = "456";
        }
    }
    class TestModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public TestModel()
        {
            
        }
        string materialPickerTitle;
        public string MaterialPickerTitle
        {
            set
            {
                if (materialPickerTitle != value)
                {
                    materialPickerTitle = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("MaterialPickerTitle"));
                    }
                }
            }
            get
            {
                return materialPickerTitle;
            }
        }
        int selectedMaterialIndex;
        public int SelectedMaterialIndex
        {
            set
            {
                if (selectedMaterialIndex != value)
                {
                    selectedMaterialIndex = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("SelectedMaterialIndex"));
                    }
                }
            }
            get
            {
                return selectedMaterialIndex;
            }
        }
    }
