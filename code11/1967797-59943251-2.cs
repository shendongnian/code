     public partial class MainPage : ContentPage
    {
        private ObservableCollection<Contacts> myList;
        public ObservableCollection<Contacts> MyList
        {
            get { return myList; }
            set { myList = value; }
        }
        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = this;
            MyList = new ObservableCollection<Contacts>();
            for (int i = 1; i < 10; i++)
            {
                MyList.Add(new Contacts() { Id = i, Name = "Student" + i.ToString(), Address = "Address" + i.ToString(), Image = "usa.png" });
            }
            ContactsList.ItemsSource = MyList;
        }
        private void ContactsList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = (Contacts)e.SelectedItem;
            if (item.Id == 1)
            {
                //.......do something you want
                 DisplayAlert("Id", "the id of item is 1", "Cancel");
            }
        }
    }
