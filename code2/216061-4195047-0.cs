    using(StreamReader re = File.OpenText("Somefile.XML"))
    {
      string input = null;
      while ((input = re.ReadLine()) != null)
      {
        MyListBox.Items.Add(input);
      }
    }
