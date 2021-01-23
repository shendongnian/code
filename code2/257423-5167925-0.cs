        var machines = new List<String>;
        machines.Add("pc1");
        machines.Add("pc1");
        foreach (var machine in machines)
        {
        var dir = new System.IO.DirectoryInfo(string.Format("\\{0}\Windows\",machine));                
            foreach (var path in dir.GetDirectories)
            {
                Console.WriteLine(path);
            }
       }
