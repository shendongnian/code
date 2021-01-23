    string line;
    string filePath = "c:\\test.txt";
    if (File.Exists(filePath))
    {
       // Read the file and display it line by line.
       StreamReader file = new StreamReader(filePath);
       while ((line = file.ReadLine()) != null)
       {
         listBox1.Add(line);
       }
         file.Close();
    }
