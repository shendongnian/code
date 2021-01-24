    using (Web_INCAEntities dc = new Web_INCAEntities())
    {
        var v = (from a in dc.TBL_PBI
                 select new Dashboard
                 {
                     id = a.id,
                     RealEjecutado =  a.RealEjecutado,
                     PlanVigente =  a.PlanVigente,
                     Reprogramacion =  a.Reprogramacion
                 });
        list = v.ToList().Select(x => new Dashboard
                 {
                     id = x.id,
                     RealEjecutado =  Decimal.TryParse(x.RealEjecutado, out decimal i) ? i.ToString("C", CultureInfo.CreateSpecificCulture("en-US")) : x.RealEjecutado,
                     PlanVigente =  x.PlanVigente,
                     Reprogramacion =  x.Reprogramacion
                 }).ToList();     
    }
    
    return View("../Dashboard/PontoHorizonte/Graficas", list);
