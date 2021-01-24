     foreach (var item in objectsToUpdate)
                {
                    var a = list1.Where(l => l.A == item.A && l.B == item.B && l.C == item.C).ToList();
        
                    if(a != null)
                    {
                        foreach(var x in a)
                        {
                           item.D = x.D;
                           item.E = x.E;
                        }
                    }
                    
                  
                    var b = list2.Where(l => l.A == item.A && l.B == item.B).ToList();
        
                    if(b != null)
                    {
                        foreach(var x in b)
                        {
                           item.D = x.D;
                           item.E = x.E;
                        }
    
                    }
                        
                       
                    var c = list3.Where(l => l.A == item.A && l.C == item.C).ToList();
        
                    if (c != null)
                    {
                        foreach(var x in c)
                        {
                           item.D = x.D;
                           item.E = x.E;
                        }
                    }
        
                }
