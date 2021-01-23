    [Serializable]
    public class Person
    {
        public String FirstName { get; set; }
    }
    
    public MainWindow()
    {
        InitializeComponent();
    
        // this now works!!
        if (Properties.Settings.Default.AllPeople == null)
        {
            Properties.Settings.Default.AllPeople = new ObservableCollection<Person> 
    		{ 
    			new Person() { FirstName = "bob" },
    			new Person() { FirstName = "sue" },
    			new Person() { FirstName = "bill" }
    		};
            Properties.Settings.Default.Save();
        }
        else
        {
            MessageBox.Show(Properties.Settings.Default.AllPeople.People.Count.ToString());
        }
    }
