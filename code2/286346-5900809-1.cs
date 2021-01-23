    IList<Element> element = new List<Element>();
                
    
                var result = new { P1 = element
                                    .Select(X => X.FirstProp).Distinct()
                                ,
                                   P2 = element
                                        .Select(X => X.SecondProp).Distinct()
                                ,
                                    element
                                   // do projections here over others 8 properties
                };
        
    
                           
