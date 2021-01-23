    private class Item 
    {
          public string _Name;
          public int _Id
    
          public Item(string name, int id) 
          {
              _Name = name; 
              _Id = id;
          }
          public string Name
          {
              get { return _Name; }
              set { _Name = value; }
          }
 
          public string Id
          {
              get { return _Id; }
              set { _Id = value; }
          }
    }   
    
    comboBox1.DisplayMember = "Name";
    comboBox1.ValueMember = "Id";
    comboBox1.Items.Add(new Item("Student 1", 1));
    comboBox1.Items.Add(new Item("Student 2", 2));
    comboBox1.Items.Add(new Item("Student 3", 3));
