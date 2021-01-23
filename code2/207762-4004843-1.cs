    List<Person> _list = new List<Person>();
    
    protected override void OnLoad(EventArgs e)
    {
        _list.Add(new Person { ID = 1, Name = "John" });
        _list.Add(new Person { ID = 2, Name = "Mary" });
    
        dataGridView1.DataSource = _list;
    }
