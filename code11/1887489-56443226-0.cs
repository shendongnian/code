    public IActionResult MyView()
            {
                return View();
            }
    [HttpPost]
    public IActionResult MyView(MyModel model)
                {
                    return View(model);
                }
