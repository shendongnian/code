            Dictionary<int, string> source = new Dictionary<int, string>();
            Dictionary<int, string> target = new Dictionary<int, string>();
            source.Add(1, "a");
            source.Add(2, "b");
            source.Add(3, "c");
            target.Add(4, "c");
            target.Add(5, "d");
            target.Add(6, "e");
            // Reverse index:
            var reverseSource = source.Reverse();
            var reverseTarget = target.Reverse();
            foreach (var sourceItem in reverseSource)
            {
                if (reverseTarget.ContainsKey(sourceItem.Key)){
                    Console.WriteLine($"Source and Target contains {sourceItem.Key}");
                }
            }
