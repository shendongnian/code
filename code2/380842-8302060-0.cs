    var results = new List<Object>();
    foreach(var i in list)
    {
        if (i.property == value)
        {
             foreach(var j in list.SubList)
             {
                  if (j.other == something)
                  {
                      results.push(j);
                  }
             }
        }
    }
    
