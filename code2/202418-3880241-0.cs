    List<int> list = new List<int>();
                    list.Add(0);
                    list.Add(0);
                    list.Add(0);
                    list.Add(1);
                    list.Add(2);
                    list.Add(3);
                    list.Add(4);
                    list.Add(0);
                    list.Add(0);
        
                    var listOne = list.Take(3);
                    var listSecond = list.Skip(3).Take(4);
                    var listThird = list.Skip(7);
