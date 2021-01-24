    public List<string> SearchList()
    {
        var dirList = new List<string>();
        var path = @"C:\Users\Precision\Desktop\testing\data.txt";
        System.Console.WriteLine("Enter CNIC or Phone No");
        string check = System.Console.ReadLine();
        using (StreamReader sr = new StreamReader(path))
        {
            var lines = sr.ReadToEnd().Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var line in lines)
            {
                if (line.Contains($"Id Card No :{check}") || line.Contains($"Phone No :{check}"))
                {
                    dirList.Add(line);
                    System.Console.WriteLine("Data Found Against {0}", check);
                }
            }
        }
        return dirList;
    }
