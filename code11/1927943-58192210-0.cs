                var enList = testDictionary.Values.Where(d => d.Name == "John" && d.Code == "JN").ToList();
            foreach (var item in enList)
            {
                item.Name = "Updated Name";
            }
            Console.WriteLine(testDictionary[1].Name);
