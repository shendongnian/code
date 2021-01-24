     public class PersonList1 : ObservableCollection<Person1>, INotifyPropertyChanged
    {
        private string _heading;
        public string Heading
        {
            get { return _heading; }
            set
            {
                _heading = value;
                RaisePropertyChanged("Heading");
            }
        }
        public ObservableCollection<Person1> Persons => this;
        
        public event PropertyChangedEventHandler PropertyChanged;       
        public void RaisePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
    public class Person1
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DisplayName
        {
            get
            {
                return $"{LastName}, {FirstName}";
            }
        }
    }
    <StackLayout>
            <ListView IsGroupingEnabled="true" ItemsSource="{Binding ListOfPeople}">
                <ListView.GroupHeaderTemplate>
                    <DataTemplate>
                        <ViewCell>
                            <Label Text="{Binding Heading}" />
                        </ViewCell>
                    </DataTemplate>
                </ListView.GroupHeaderTemplate>
                <ListView.ItemTemplate>
                    <DataTemplate>
                        <ViewCell>
                            <Label Text="{Binding DisplayName}" />
                        </ViewCell>
                    </DataTemplate>
                </ListView.ItemTemplate>
            </ListView>
            <Button
                x:Name="btn1"
                Clicked="Btn1_Clicked"
                Text="change header" />
        </StackLayout>
    public partial class Page15 : ContentPage
	{
        public ObservableCollection<PersonList1> ListOfPeople { get; set; }
       
        public Page15 ()
		{
			InitializeComponent ();
            var sList = new PersonList1()
    {
        new Person1() { FirstName = "Sally", LastName = "Sampson" },
        new Person1() { FirstName = "Taylor", LastName = "Swift" },
        new Person1() { FirstName = "John", LastName = "Smith" }
    };
            sList.Heading = "S";
            var dList = new PersonList1()
    {
        new Person1() { FirstName = "Jane", LastName = "Doe" }
    };
            dList.Heading = "D";
            var jList = new PersonList1()
    {
        new Person1() { FirstName = "Billy", LastName = "Joel" }
    };
            jList.Heading = "J";
            ListOfPeople = new ObservableCollection<PersonList1>()
    {
        sList,
        dList,
        jList
    };
            this.BindingContext = this;
        }
        private void Btn1_Clicked(object sender, EventArgs e)
        {
            ListOfPeople[0].Heading = "this is test";
        }
    }
