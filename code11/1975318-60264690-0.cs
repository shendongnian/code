     var results = StudentsList.Where(x => x.University == "OPQ").GroupBy(x => x.GroupID).ToList();
                foreach (var item in results)
                {
                    Console.WriteLine("Group " + item.Key + " , " + item.FirstOrDefault().Student); 
                }
