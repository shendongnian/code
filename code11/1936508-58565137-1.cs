List<string> prods = new List<string>();
            prods.AddRange(new List<string>() {
                "Apple",
                "Apricot",
                "Banana",
                "Blueberry",
                "Fig",
                "Grape"
            });
            //Considering that the list is already sorted alphabetically
            //or you can use prods.Sort();
            List<string> newList = new List<string>();
             string alphabets = "abcdefghijklmnopqrstuvwxyz";
            foreach(char a in alphabets)
            {
                newList.Add(a.ToString());
                foreach (var item in prods)
                {
                    if (item.StartsWith(a.ToString()) || item.StartsWith(a.ToString().ToUpper()))
                    {
                        Console.WriteLine($"adding {item} to  newlist");
                        newList.Add(item);
                    }
                }
            }
            foreach (var item in newList)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
Please let me know how it works out for you.            
