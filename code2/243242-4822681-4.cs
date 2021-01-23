    [HttpPost]
    public JsonResult LastSeenPractice(string practiceID, List<String> doctorIDs)
    {            
        ... process query ...
        return Json(new { pid = practiceID, LastSeenPractice = lastSeenPractice, LastSeenDoctor = lastSeenDoctor });
    }
