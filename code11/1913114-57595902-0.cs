    //Get the Company with id == 1030.
        var x = _context.Companies.Include(a => a.AddressNavigation).Include(c => c.Cars).Where(c => c.CompanyId == id).FirstOrDefault();
    
    //Get the Car ICollection and include the CarImages ICollection depending on CompanyID. 
        var y = _context.Cars.Include(img => img.CarImages).Where(cr => cr.CompanyId == x.CompanyId).ToList();
    
    //Now each Car in our Cars list has a list of CarImages related to each car. Finaly pass our data to our Company var(x) and send it to View.
        x.Cars = y;
        return View(x);
