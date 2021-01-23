    string line;
    while ((line = reader.ReadLine()) != null)
    {
      HashTable lines = new HashTable();
      if(lines.ContainsKey(line) == false) lines.Add(line);
    }
