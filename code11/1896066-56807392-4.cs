    void Modify()
    {
        using (var fs = new FileStream(file, FileMode.Open, FileAccess.ReadWrite))
        {
            string line;
            long position;
            while ((line = fs.ReadLine(out position)) != null)
            {
                var tmp = line.Split(',');
                tmp[1] = "00"; // new value
                var newLine = string.Join(",", tmp);
                fs.WriteLine(position, newLine);
            }
        }
    }
