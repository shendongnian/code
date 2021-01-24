    var listOne = new List<string>();
    var listTwo = new List<string>();
    
                foreach (var item in listWithDuplicats)
                {
                    if (!listOne.Contains(item))
                    {
                        listOne.Add(item);
                    }
                    else
                    {
                        listTwo.Add(item);
                    }
                }
