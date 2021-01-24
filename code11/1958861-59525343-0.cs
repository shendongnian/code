    var line = $"13351.750815 26646.150876 6208.767863 26646.150876 1219.200000 914.400000 0.000000 1 \"Beam 1\" 0 1 1 1 0 1 1e8f59dd-142d-4a4d-81ff-f60f93f674b3";
        string[] splitLineResult = line.Trim().Split('"');
        var list = new List<string[]>();
        for (int i = 0; i < splitLineResult.Length; i++)
        {
            if (i % 2 == 0) 
            {
                list.Add(splitLineResult[i].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
            }
            else 
            {
                list.Add(new string[] { splitLineResult[i] });
            }
        }
        var finalList = list.SelectMany(x=>x).ToList();
