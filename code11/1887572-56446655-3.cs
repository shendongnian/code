            [HttpGet]
            public async Task<IActionResult> YourGetMethod(string dropDownChoice)
            {
                //Handle logic of drop down choice and populate the model accordingly
                return PartialView(partialViewName, YourModel);
            }
