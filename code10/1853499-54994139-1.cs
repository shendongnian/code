    [HttpGet]
        public ActionResult ClickDetails()
        {
            // set view model with dropdown values, also you can use linq from your list of values
            var formModel = new PlaneFormModel
            {
                DropDownValues = new List<SelectListItem>
                {
                    new SelectListItem
                    {
                        Key = "key",
                        Value = "val"
                    }
                }
            };
            
            return View(formMmodel);
        }
