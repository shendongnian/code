    public ActionResult Edit(int id)
    {
         var viewModel = new StoreManagerViewModel
         {
             Album = storeDB.Albums.SingleOrDefault(a => a.AlbumId == id),
             Genres = storeDB.Genres.ToList(),
             Artists = storeDB.Artists.ToList()
         };
    
         ViewData["Artists"] = storeDB.Artists.ToList();
         ViewData["Genres"] = storeDB.Genres.ToList();
    
         return View(viewModel);
     }
