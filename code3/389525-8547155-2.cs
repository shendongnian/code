    HashTable lines = new System.Collections.HashTable();
    string line;
    // Read each line of the file until the end
    while ((line = reader.ReadLine()) != null)
    {
      // Check that we have not yet seen this string before
      if(lines.ContainsKey(line) == false) 
      {
        lines.Add(line, 0);
        // You can write the lines to another file in necessary
        writer.WriteLine(line);
      }
    }
