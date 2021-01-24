      ListBox listBox1 = new ListBox();
      for (int x = 1; x <= 5; x++)
      { 
        listBox1.Items.Add("Item " + x.ToString());
      }
      StringBuilder sb = new StringBuilder();
      foreach (var item in listBox1.Items)
      {
        sb.Append(item.ToString());
      }
      Console.WriteLine(sb.ToString());
