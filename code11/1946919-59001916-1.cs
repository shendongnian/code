     foreach (var tem in objectsToUpdate)
                {
                    var a = list1.Where(l => l.A == item.A && l.B == item.B && l.C == item.C).ToList();
        
                    if(a != null)
                    {
                        foreach(var x in a)
                        {
                            x.D = item.D;
                            x.E = item.E
                        }
                    }
                    
                  
                    var b = list2.Where(l => l.A == item.A && l.B == item.B).ToList();
        
                    if(b != null)
                    {
                        foreach(var x in b)
                        {
                            x.D = item.D;
                            x.E = item.E
                        }
    
                    }
                        
                       
                    var c = list3.Where(l => l.A == item.A && l.C == item.C).ToList();
        
                    if (c != null)
                    {
                        foreach(var x in c)
                        {
                            x.D = item.D;
                            x.E = item.E
                        }
                    }
        
                }
