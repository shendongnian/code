    public static void Edit(Transformable o, string fileName)
    {
        try
        {
            string tempName = "temp.txt"; // create here correct path
            using (var readStream = File.OpenRead(fileName))
            using (var writeStream = File.OpenWrite(tempName))
            using (var reader = new StreamReader(readStream))
            using (var writer = new StreamWriter(writeStream))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (!line.Equals(""))
                    {
                        if (o.GetId() == GetId(line))
                        {
                            writer.WriteLine(o.ToWriteableString());
                        }
                        else
                        {
                            writer.WriteLine(line);
                        }
                    }
                }
            }
            File.Delete(fileName);
            File.Move(tempName, fileName);
        }
        catch ...
    }
