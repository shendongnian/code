    listBox1_SelectedIndexChanged(obj ... , sender e)
    {
         if(listBox1.SelectedItem.ToString() == "Fruit")
         {
            listBox2.Items.Add("Orange");
            listBox2.Items.Add("Apple");
          }
         else if()
         {
            // other conditons
          }
    }
    
    listBox2_SelectedIndexChanged(obj ... , sender e)
    {
         if(listBox2.SelectedItem.ToString() == "Apple")
         {
            listBox3.Items.Add("Red");
            listBox3.Items.Add("Green ");
          ........
          }
         else if()
         {
            // other conditons
          }
    }
