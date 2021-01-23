    list = new List<Person>();
    list.Add(new Person { ID = 1, Name = "Name 1", Age = 21 });
    list.Add(new Person { ID = 2, Name = "Name 2", Age = 28 });
    list.Add(new Person { ID = 3, Name = "Name 3", Age = 44 });
    textBox1.DataBindings.Add(new Binding("Text", list[0], "Name", false));
    textBox2.DataBindings.Add(new Binding("Text", list[1], "Name", false));
    textBox3.DataBindings.Add(new Binding("Text", list[2], "Name", false));
    internal class Person
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
