    [Route("customers/show/{id:int}")]
    public ActionResult Show(int? id)
    {
        if (!id.HasValue) {
                return Redirect("/customers");  // Or return HttpNotFound();
        }
        var customer = GetCustomers().FirstOrDefault(c => c.Id == id.Value);
        if (customer == null)
        {
            return Redirect("/customers");  // Or return HttpNotFound();
        }
        return View(customer);
    }
