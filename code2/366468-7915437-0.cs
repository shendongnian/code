        List<string> lines = new List<string>();
        using (var sr = File.OpenText("C:\\test.txt"))
        {
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                lines.Add(line); 
            }
        }
        lines.Reverse();
