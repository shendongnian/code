    public List<string> SearchList()
    {
        var path = @"C:\Users\Precision\Desktop\testing\data.txt";
        Console.WriteLine("Enter CNIC or Phone No");
        var check = Console.ReadLine();
        var dirList = new List<string>();
        using (StreamReader sr = new StreamReader(path))
        {
            var lines = sr.ReadToEnd()
                          .Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var line in lines)
            {
                if (line.Contains($"Id Card No :{check}") || line.Contains($"Phone No :{check}"))
                {
                    dirList.Add(line);
                }
            }
        }
        return dirList;
    }
