    [Subaction("Details")]
    public ActionResult Members(long id)
    {
        var member = _payment.GetMember(id);
        return View("Members_details", member);
    }
    
    [Subaction] // no name would mean "default"
    public ActionResult Members()
    {
        var members = _payment.GetMembers().ToList();
        return View("Members_list", members);
    }
