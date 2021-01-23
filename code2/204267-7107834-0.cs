        using (var w = new StreamWriter(File.Create("file.txt"), System.Text.Encoding.UTF8))
        {
            for (int i = 0; i < 1000; i++)
            {
                w.WriteLine("Test");
            }
        }
