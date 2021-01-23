    int value = 0;
    string line;
    while ((line = reader.ReadLine()) != null)
    {
      HashTable lines = new HashTable();
      if(lines.ContainsKey(line) == false) 
      {
        lines.Add(line, value);
        // You can write the lines to another file
        writer.WriteLine(line);
      }
    }
