    public ActionResult Edit(string id)
    {
        var publisher = _service.GetPublisher(id);
        
        var viewModel = new PublisherViewModel
        {
            Titles = publisher.Titles.Select(x => new TitleViewModel
            {
                Id = x.Name,
                IsChecked = true
            })
        };
    
        return View(model);
    }
    [HttpPost]
    public ActionResult Update(PublisherViewModel model)
    {
        if (!ModelState.IsValid)    
        {
            return View(model);
        }
        var publisher = ... map the view model to a domain model
        _service.UpdatePublisher(publisher);
        return RedirectToAction("Publishers");
    }
