    Dictionary<int, string> map = new Dictionary<int, string>();    
    using (FileStream fs = new FileStream(inputFile, FileMode.Open)
    using (StreamReader sr = new StreamReader(fs)
    {
        while (sr.Peek() >= 0) 
        {
            string[] split = string.Split(".", sr.ReadLine());
    
            int num = int.Parse(split[0]);
            string msg = split[1];
    
            map.Add(num, msg);
        }
    }
