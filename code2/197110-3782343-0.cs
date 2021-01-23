    public ActionResult FindZipCode(string term)
    {
        string[] zipCodes = customerRepository.FindFilteredZipCodes(term);
        return Json(new { suggestions = zipCodes }, JsonRequestBehavior.AllowGet);
    }
