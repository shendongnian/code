       public ActionResult PartialTabelaEcp(string json)
       { 
    	   PartialTableEcpModel tableModel = new PartialTableEcpModel();
       	   tableModel.Days = new List<string>() {"Day1", "Day2", Day3};
           var nr_days= 31;
           ViewBag.days= nr_days;
           return PartialView("_TableEve", tableModel);
       }
