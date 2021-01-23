           List<string> name = new List<string>();   
            name.Add("Latif");
            name.Add("Ram");
            name.Add("Adam");
            string nameOfString = (string.Join(",", name.Select(x => x.ToString()).ToArray()));
