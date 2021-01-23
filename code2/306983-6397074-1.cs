    public ActionResult Index()
    {
        // TODO: it would be better to externalize the parsing of the XML
        // file into a separate repository class to avoid cluttering your
        // controller actions with such code which is not what they should
        // be responsible for. But for the purpose of this answer it should 
        // be enough 
        var file = Path.Combine(Server.MapPath("~/app_data"), "crm.xml");
        var model = new UnitViewModel
        {
            Units = 
                from unit in XDocument.Load(file).Document.Descendants("Unit")
                select new SelectListItem
                {
                    Value = unit.Attribute("ID").Value,
                    Text = unit.Attribute("Name").Value
                }
        };
        return View(model);
    }
