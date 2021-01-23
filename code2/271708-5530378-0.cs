    arrayList.ToList().Select(i => { var split = i.Split(":".ToArray(),2));
                                    return new { a = Int32.Parse(split[0]),
                                                 b = Int32.Parse(split[1}) }; 
                                   })
    .OrderByDescending(i => i.a)
    .ThenBy(i => i.b)
