public IActionResult Get(Obj blah)
{
    if (ModelState.IsValid) 
    { 
       ...
       return View("WhateverPageIsAfterSuccess")
    }
    return RedirectToAction("IndexAction")
}
