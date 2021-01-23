    [HttpGet]
    public ActionResult Edit(int id)
    {
      var item = this.db.Items.Find(id);
      var model = CX.Mapper.Mapping.MapNew<Item, ItemDto>(item);
      return View(model);
    }
    
    [HttpPost]
    public ActionResult Edit(ItemDto model)
    {
      if(Model.IsValid)
      {
        var item = this.db.Items.Find(ItemDto.Id);
        CX.Mapper.Mapping.Map<ItemDto, Item>(model, item);
        this.db.SaveChanges();
        return RedirectToAction("Index");
      }
      return View(model);
    }
