     protected List<Person> persons = new List<Person>();
    protected void Page_Load(object sender, EventArgs e)
            {
                persons.Add(new Person() { Name = "Toto", Firstname="Bobo" });
                persons.Add(new Person() { Name = "Titi", Firstname = "Bibi" });
            }
