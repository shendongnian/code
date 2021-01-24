        [HttpPost] 
    public async Task<ActionResult> CreateEdit(Parent model)
    {
        // check if its Null or Not
        var IsItNull = model.SubDTO.Name;   
        return RedirectToAction($"{ControllerEntity}Manager");
    }
