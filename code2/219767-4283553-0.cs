    public ActionResult DownloadPersonalMessages()
    {
        StringBuilder myCsv = new StringBuilder();
        myCsv.Append(new DownloadService().GetPersonalMessages());
        Response.AddHeader("Content-Disposition", "attachment; filename=PersonalMessages.csv");
        return File(Encoding.UTF8.GetBytes(myCsv.ToString()), "text/csv");
    }
