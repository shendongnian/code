    [Route("customers/show/{id}")]
    public ActionResult Show(string id)
    {
        if (!int.TryParse(id, out var parsedId)) {
            return Redirect("/customers");  // Or return HttpNotFound();
        }
        // Note: You should really pass your Id into GetCustomers somehow or else it'll pull 
        //everything from your database first and then find the one customer in memory
        var customer = GetCustomers().FirstOrDefault(c => c.Id == parsedId);
        if (customer == null)
        {
            return Redirect("/customers");  // Or return HttpNotFound();
        }
        return View(customer);
    }
