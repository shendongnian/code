     public partial class MainPage : UserControl
    {
        PersonContract personContract = new PersonContract();
        
        public MainPage()
        {
            InitializeComponent();
            personContract.personList = new System.Collections.ObjectModel.ObservableCollection<Person>();
            for (int x = 0; x < 10; x++)
            {
                personContract.personList.Add(new Person() { FaxNo = "123456", IdNo = "8002135104089", Name = "Pieter", RegNo = "YMY863GP", Surname = "Stoltz", TelNo = "00129394" });
            }
            mygrid.DataSource = personContract.personList;
        }
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            personContract.personList.Add(new Person() { FaxNo = "123456", IdNo = "8002135104089", Name = "Santie", RegNo = "YMY863GP", Surname = "Van den Heever", TelNo = "00129394" });
        }
    }
    public class PersonContract
    {
        public System.Collections.ObjectModel.ObservableCollection<Person> personList { get; set; }
    }
    public class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string TelNo { get; set; }
        public string FaxNo { get; set; }
        public string IdNo { get; set; }
        public string RegNo { get; set; }
    }
