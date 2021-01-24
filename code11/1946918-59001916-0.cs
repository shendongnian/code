     foreach (var item in objectsToUpdate)
                {
                    var a = list1.Where(l => l.A == item.A && l.B == item.B && l.C == item.C).ToList();
        
                    if(a != null)
                    {
                                a.foreach(x=>{
                        x.D = Item.D;
                        x.E = Item.E
                        });
                    }
                    
                  
                    var b = list2.Where(l => l.A == item.A && l.B == item.B).ToList();
        
                    if(b != null)
                    {
                            b.foreach(x=>{
                        x.D = Item.D;
                        x.E = Item.E
                        });
                    }
                        
                       
                    var c = list3.Where(l => l.A == item.A && l.C == item.C).ToList();
        
                    if (c != null)
                    {
                        c.foreach(x=>{
                        x.D = Item.D;
                        x.E = Item.E
                        });
                    }
        
                }
