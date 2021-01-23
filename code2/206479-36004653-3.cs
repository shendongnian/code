    pubblic Class PassengerDetailContext : DbContext 
    {
      pubblic DbSet<PassengerDetail>  passegerDetails {get;set;}
    }
    List<PassengerDetail> passegerDetails = new List<PassengerDetail>();
    list = db.passegerDetails.ToList();
    return View(list);
