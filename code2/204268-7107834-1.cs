        using (var w = File.CreateText("file.txt"))
        {
            for (int i = 0; i < 1000; i++)
            {
                w.WriteLine("Test");
            }
        }
