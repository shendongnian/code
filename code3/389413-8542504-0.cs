    public ActionResult ShowProfile(int id)
    {
        var model = new WhateverTheClassNameIs().GetProfileCustomer(id);
        return View(model);
    } 
