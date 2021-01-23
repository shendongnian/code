    private class Item 
    {
          public string Name;
          public int Id
    
          public Item(string name, int id) 
          {
              Name = name; 
              Id = id;
          }
    }   
    
    comboBox1.Items.Add(new Item("Student 1", 1));
    comboBox1.Items.Add(new Item("Student 2", 2));
    comboBox1.Items.Add(new Item("Student 3", 3));
