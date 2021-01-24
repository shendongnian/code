    public ActionResult Index(string key = "")
                {
                    Registration registration = new Registration
                    {
                        UniqueLink= key
                    };
                    return View(registration);
                }
