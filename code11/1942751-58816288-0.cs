     List<List<string>> d = new List<List<string>>(); //SuperList
            d.Add(new List<string> { "a", "b" }); //List 1
            d.Add(new List<string> { "a", "b" }); // List 2
            d.Add(new List<string> { "a", "c" }); // List 3
            d.Add(new List<string> { "a", "c", "z" }); //List 4
            var listCount = from items in d
                            group items by items.Aggregate((a,b)=>a+""+b) into groups
                            select new { groups.Key, Count = groups.Count() };
