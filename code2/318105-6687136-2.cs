    [HttpPost]
    [Authorize(Roles = "Administrator, SuperUser")]
    public ActionResult AddTableTo(VipSeatingAreaViewModel seatingArea, string nextButton)
    {
        if (nextButton != null)
            return RedirectToAction("AddTableToTable", new { sid = seatingArea.SeatingAreaId, vid = seatingArea.VipServiceId });
        return View(seatingArea);
    }
