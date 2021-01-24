    var Q = from Cx in db.Carnets select Cx;
        
    if (!string.IsNullOrWhitespace(carnet.CarnetNumber))
    {
        var withCarnetNumber = from Cx in Q
        	where Cx.CarnetNumber.Contains(carnet.CarnetNumber)
        	select Cx;
    }
    if (!string.IsNullOrWhitespace(carnet.Holder))
    {
        var withCarnetHolder = from Cx in Q
        	where Cx.CarnetHolder.Contains(carnet.Holder)
        	select Cx;
    }
    
    ...
    var result = withCarnetNumber.Union(withCarnetHolder).Union(...).ToList();
