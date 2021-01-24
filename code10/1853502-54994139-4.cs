    [HttpGet]
        public ActionResult ClickDetails()
        {
            // set view model with dropdown values, also you can use linq from your list of values
            // also you can set default value for dropdown
            var formModel = new PlaneFormModel
            {
                DropDownValueSelected = "defaultValue", // <---- value
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
