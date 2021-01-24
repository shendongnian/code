    [HttpPost]
    public ActionResult<MyModelType> Post([FromBody] NewModel data) {
        if (ModelState.IsValid) {
            var model = MyList.AddItem(data.NewName, data.NewAge, data.NewWeight);
            return model;
        }
        return BadRequest(ModelState);
    }
