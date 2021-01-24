    Request.Itmelist c1 = new Request.Itmelist() { ItmeID = "1", ItmeName = "A1", ItmeStartDate = "20190901185703", ItmeEndDate = "20190930235959" };
    Request.Itmelist c2 = new Request.Itmelist() { ItmeID = "2", ItmeName = "A2", ItmeStartDate = "20190903181510", ItmeEndDate = "20190906235959" };
    Request.Itmelist c3 = new Request.Itmelist() { ItmeID = "3", ItmeName = "A3", ItmeStartDate = "20190906005152", ItmeEndDate = "20191006235959" };
    Request.Itmelist c4 = new Request.Itmelist() { ItmeID = "4", ItmeName = "A4", ItmeStartDate = "20190714181313", ItmeEndDate = "20991231235959" };
    
    
    var requestTimes = new List<Request.Itmelist>() { c1, c2, c3, c4 };
    
    
    List<Response.Responselist> res = new List<Response.Responselist>();
    Responselist obj = new Responselist();
    
    obj.resultCode = "1";
    obj.resultText = "success";
    obj.Itmebalance = "15";
    obj.ItmeTypeName = "TT";
    obj.ResponseItmes = requestTimes.Select(i => new Itme
    {
    	ItmeEndDate = i.ItmeEndDate,
    	ItmeName = i.ItmeName,
    	ItmeStartDate = i.ItmeStartDate
    }).ToList();
    
    
    res.Add(obj);
