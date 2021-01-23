    var path = "fileName.txt";
                
    var names = new List<string>();
    var values = new List<KeyValuePair<int, int>>();
    
    using (var reader = File.OpenText(path))
    {
            string s = "";
            while ((s = reader.ReadLine()) != null)
            {
                String[] arr = s.Split(' ');
                names.Add(arr[0]);
                values.Add(new KeyValuePair<int, int>(int.Parse(arr[1]), int.Parse(arr[2])));
            }
    }
