    public partial class Form1 : Form
    {
        private List<Person> people = new List<Person>();
        private List<Address> addresses = new List<Address>();
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            FillPeople();
            FillAddresses();
            radGridView1.DataSource = people;
            GridViewTemplate template = new GridViewTemplate();
            template.DataSource = addresses;
            radGridView1.MasterTemplate.Templates.Add(template);
            GridViewRelation relation = new GridViewRelation(radGridView1.MasterTemplate);
            relation.ChildTemplate = template;
            relation.RelationName = "PersonAddress";
            relation.ParentColumnNames.Add("Id");
            relation.ChildColumnNames.Add("PersonId");
            radGridView1.Relations.Add(relation);
        }
        private void FillPeople()
        {
            Person richard = new Person();
            richard.Name = "Richard";
            richard.Id = 1;
            people.Add(richard);
            Person bob = new Person();
            bob.Name = "Bob";
            bob.Id = 2;
            people.Add(richard);
            Person mike = new Person();
            mike.Name = "Mike";
            mike.Id = 3;
            people.Add(mike);
        }
        private void FillAddresses()
        {
            Address house1 = new Address();
            house1.PersonId = 1;
            house1.Id = 1;
            house1.theAddress = "1 The Mews";
            addresses.Add(house1);
            Address house2 = new Address();
            house2.PersonId = 2;
            house2.Id = 2;
            house2.theAddress = "2 The Mews";
            addresses.Add(house2);
        }
    }
    class Person 
    {     
        public int Id {get;set;}     
        public string Name {get;set;}     
              
        
        public Person()     
        { }      
        
    }
 
    class Address  
    {
        public int Id { get; set; }   
        public int PersonId {get;set;}    
        public string theAddress {get;set;}     
        public Address()
        { }
    }
}
