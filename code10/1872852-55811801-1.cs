    [HttpGet]
    [Route("api/v1/cards")]
    public IActionResult Cards(inputParameters,selector,filtering)
    {
        return OK(new ViewModel 
               { 
                    Property1 = FromJson.Something, 
                    Property2 = FromJson.Something44, 
                    Property3 = FromJson.Something79 
               });
    }
