        using (StreamReader reader = new StreamReader("file.txt"))
        using (StreamWriter writer = new StreamWriter("newfile.txt"))
            //Use a while loop that reads each line until there are none left 
            while (reader.ReadLine() != null)
            {
                if (reader.ReadLine().StartsWith("Report"))
                    writer.WriteLine(reader.ReadLine());
                {
                    while (reader.ReadLine().StartsWith("Report").Equals(true))
                    {
                        writer.Write(reader.ReadLine());
                    }
                }
            }
