    List<Person> list;
    public Form1()
    {
       InitializeComponent();
       list = new List<Person>();
       list.Add(new Person { ID = 1, Name = "Name 1", Age = 21 });
       list.Add(new Person { ID = 2, Name = "Name 2", Age = 28 });
       textBox1.DataBindings.Add(new Binding("Text", list, "ID", false));
       textBox2.DataBindings.Add(new Binding("Text", list, "Name", false));
       textBox3.DataBindings.Add(new Binding("Text", list, "Age", false));
    }
    internal class Person
    {
       public int ID { get; set; }
       public string Name { get; set; }
       public int Age { get; set; }
    }
