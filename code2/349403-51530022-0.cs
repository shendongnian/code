     List<int> ListInt = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
    
    
                int count = ListInt.Count;
                int index = 1;
                foreach (var item in ListInt)
                {
                    if (index != count)
                    {
                        Console.WriteLine("do something at index number  " + index);
                    }
                    else
                    {
                        Console.WriteLine("Foreach loop, this is the last iteration of the loop " + index);
                    }
                    index++;
    
                }
                //OR
                int count = ListInt.Count;
                int index = 1;
                foreach (var item in ListInt)
                {
                    if (index < count)
                    {
                        Console.WriteLine("do something at index number  " + index);
                    }
                    else
                    {
                        Console.WriteLine("Foreach loop, this is the last iteration of the loop " + index);
                    }
                    index++;
    
                }
