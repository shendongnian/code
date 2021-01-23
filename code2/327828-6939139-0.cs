    public ActionResult DetailsChanged(DetailsRepository detailsRepository, Details detailsModel)
    {
      if(!ModelState.Valid)
    {
       ViewData["Error"] = "Error";
       return View();
    }
    Details newDetails = detailsRepository.FirstOrDefault(x => x.ID == detailsModel.Id);
    if(newDetails != null)
    {
       if(newDetails.Id == 1)
       {
          newDetails.Id = 2;
       } else {
          newDetails.Id = 2;
       }
       detailsRepository.SaveChanges();
       return View();
     }
    }
