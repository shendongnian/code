      public static Position Centroid(IEnumerable<Position> pts) 
      { 
        double a = SignedArea(pts); 
     
        var  c = pts.Pairwise((p1, p2) => new  
                                          {  
                                            x = (p1.X + p2.X) * (p1.X * p2.Y - p2.X * p1.Y),  
                                            y = (p1.Y + p2.Y) * (p1.X * p2.Y - p2.X * p1.Y)    
                                          }) 
                    .Aggregate((t1, t2) => new  
                                           {  
                                             x = t1.x + t2.x,  
                                             y = t1.y + t2.y  
                                           }); 
     
        return new Position(1.0 / (a * 6.0) * c.x, 1.0 / (a * 6.0) * c.y); 
      } 
