            Dictionary<int, string> source = new Dictionary<int, string>();
            Dictionary<int, string> target = new Dictionary<int, string>();
            source.Add(1, "a");
            source.Add(2, "b");
            source.Add(3, "c");
            target.Add(4, "c");
            target.Add(5, "d");
            target.Add(6, "e");
            foreach(var sourceItem in source)
            {
                foreach(var targetItem in target)
                {
                    if(sourceItem.Value == targetItem.Value)
                    {
                        Console.WriteLine($"Found match - SourceKey: {sourceItem.Key} | Tagetkey: {targetItem.Key}");
                    }
                    
                }
            }
