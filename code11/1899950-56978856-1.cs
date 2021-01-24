    class Form
    {
        // the BindingListView from the nuget package:
        private readonly BindingListView<Person> sortableBindingListView;
        // constructor
        public Form1()
        {
            InitializeComponent();
            // make sure there is a Components Container, that will dispose
            // the components upon disposal of the form
            if (this.components == null)
            {
                this.components = new System.ComponentModel.Container();
            }
            // construct the sortable BindingListView for Persons:
            this.sortableBindingListView = new BindingListView<Person>(this.components);
            // create some Persons:
            var persons = new Person[]
            {
                new Person{Id = 1, Name = "F", BirthDate = new DateTime(2000, 1, 1)},
                new Person{Id = 2, Name = "A", BirthDate = new DateTime(1998, 4, 7)},
                new Person{Id = 3, Name = "C", BirthDate = new DateTime(2011, 3, 8)},
                new Person{Id = 4, Name = "Z", BirthDate = new DateTime(1997, 2, 3)},
                new Person{Id = 5, Name = "K", BirthDate = new DateTime(2003, 9, 5)},
            };
            // Assign the DataSources:
            this.sortableBindingListView.DataSource = persons;
            this.dataGridView1.DataSource = this.sortableBindingListView;
        }
    }
