    using (var reader = new StreamReader("file.txt"))
    {
         string line = null;
         while ((line = reader.ReadLine()) != null)
         {
             var rowItems = line.Split(' ').Select(Convert.ToDouble);
             matrix.Add(rowItems);
         }
    }
