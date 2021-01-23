    public JsonResult AjaxFindByName(string term)
    {
        var customers = context.Customers
            .Where(c => c.Name.ToUpper().Contains(term.ToUpper())).Take(10)
            .AsEnumerable()
            .Select(c => new { 
                value = c.Name, 
                SSN = String.Format(@"{0:000\-00\-0000}", c.SSN),
                CustomerID = c.CustomerID });
            
        return Json(customers, JsonRequestBehavior.AllowGet);
    }
