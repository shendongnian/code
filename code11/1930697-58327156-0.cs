    if (e.Data.GetDataPresent("text/x-moz-url"))    //Chrome, Firefox
     {
          MemoryStream data = (MemoryStream)e.Data.GetData("text/x-moz-url");
          string dataStr = Encoding.Unicode.GetString(data.ToArray());
          string[] parts = dataStr.Split(((char)10));
          for (int i = 0; i < parts.Count(); i++ )
          {
              listBox1.Items.Add(parts[i]);
          }
    }
