            //This can be just public IActionResult if you are not planning on 
            //using async methods inside of the controller action
            [HttpGet]
            public async Task<IActionResult> YourGetMethod(string dropDownChoice) 
            {
                //Handle logic of drop down choice and populate the model accordingly
                return PartialView(partialViewName, YourModel);
            }
