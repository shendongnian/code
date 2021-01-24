    public JsonResult GetClients(string term)
    {
       List<string> ClientsJson;
       ClientsJson = db.Clients.Where(x => x.Name.StartsWith(term))
                                 .Select(selector: x => x.Name + ((x.Adress1 == null) ? " " : "-" + x.Adress1)).ToList();
       return Json(ClientsJson, JsonRequestBehavior.AllowGet);
    } 
