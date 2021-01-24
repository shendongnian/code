    [HttpPost]
    public IActionResult Post(string[] slist)
    {
        try
        {
            foreach (var s in slist)
            {
               // do something
               if(NotValid(s))
               {
                    ModelState.AddModelError("", "Your message to the client");
               }
            }
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(new { successMessage = "success"});
        }
        catch(Exception ex)
        {
            // log your exception
            ModelState.AddModelError("", "Your generic error message");
            ModelState.AddModelError("SomeProperty", "Your error message about 'SomeProperty'");
            return BadRequest(ModelState);
        }
    }
