        string line;
        // Read the file and display it line by line.
        StringWriter writer = new StringWriter(); // System.IO;
        System.IO.StreamReader file = new System.IO.StreamReader("C:\\Panda.txt");
        while ((line = file.ReadLine()) != null)
        {
            if (line.Contains("Number of files infected"))
            {
                
                writer.WriteLine("Panda " + line);
            }
        }
        file.Close();
        file = new StreamReader("C:\\NextPanda.txt");
        while ((line = file.ReadLine()) != null)
        {
            if (line.Contains("Number of files infected"))
            {
                writer.WriteLine("Panda " + line);
            }
        }  
        MessageBox.Show(writer);
        file.Dispose();
        System.IO.File.Delete("C:\\Panda.txt");
        System.IO.File.Delete("C:\\NextPanda.txt");
