    public Form1()
    {
     InitializeComponent();
     
     SortableBindingList<person> persons = new SortableBindingList<person>();
     persons.Add(new Person(1, "timvw", new DateTime(1980, 04, 30)));
     persons.Add(new Person(2, "John Doe", DateTime.Now));
     
     this.dataGridView1.AutoGenerateColumns = false;
     this.ColumnId.DataPropertyName = "Id";
     this.ColumnName.DataPropertyName = "Name";
     this.ColumnBirthday.DataPropertyName = "Birthday";
     this.dataGridView1.DataSource = persons;
    }
