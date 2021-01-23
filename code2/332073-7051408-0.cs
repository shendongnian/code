    public ActionResult Index()
    {
        private ClientRepository _cr = new ClientRepository();
        var _retailclients = _cr.GetRetailClientNames().ToDictionary(c => c.id);
        var _corporateclients = _cr.GetCorporateClientNames().ToDictionary(c => c.id);
        var _visits = _db.GetAllServiceVisits();
    
        var _temp = _visits.Select(o => new ServiceVisitViewModel
            {
                service_visit = o,
                client = (o.client_type ? _corporateclients[o.client_id].name : _retailclients[o.client_id].name)
            }).ToArray();
    
        return View(_temp);
    }
