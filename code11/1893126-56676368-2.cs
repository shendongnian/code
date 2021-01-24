    var Q = from Cx in db.Carnets select Cx;
        
    if (string.IsNullOrWhitespace(carnet.CarnetNumber))
    {
        Q = Q.Union(from Cx in Q
        	where Cx.CarnetNumber.Contains(carnet.CarnetNumber)
        	select Cx);
    }
    
    ...
    var result = Q.ToList();
