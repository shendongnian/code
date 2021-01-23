    string[] arr = new string[] { "^BI", "connectORCL", "^CR", "connectCR" };    
    
    var dictionary = arr.Select((value,i) => new {Value = value,Index = i})
                    .GroupBy(value => value.Index / 2)
                    .ToDictionary(g => g.FirstOrDefault().Value, 
                                       g => g.Skip(1).FirstOrDefault().Value);
