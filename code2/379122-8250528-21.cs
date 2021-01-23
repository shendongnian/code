    foreach (var obj in objects.OfType<IX>()
                               .OfType<IY>()
                               .OfType<IZ>()
                               .Select(o => new 
                                       {
                                          AsIX = (IX)o,
                                          AsIY = (IY)o,
                                          AsIZ = (IZ)o
                                       }) 
    {  
        obj.AsIX.DoX();  
        obj.AsIY.DoY();  
        obj.AsIZ.DoZ();
    } 
