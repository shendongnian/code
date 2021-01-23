    [Subaction("Details")]
    public ActionResult Members(long id)
    {
        var member = _payment.GetMember(id);
        return View("Members.Details", member);
    }
    
    [Subaction] // no name would mean default subaction (when not provided)
    public ActionResult Members()
    {
        var members = _payment.GetMembers().ToList();
        return View("Members.List", members);
    }
