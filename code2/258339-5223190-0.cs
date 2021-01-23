    public ActionResult SomeAction(SomeModel someModel)
            {
                if (ModelState.IsValid)
                {
                    //do something
                    TempData["Success"] = "Success message text.";
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewData["Error"] = "Error message text.";
                    return View(someModel);
                }
            }
