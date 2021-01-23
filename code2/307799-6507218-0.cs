    public ActionResult DownloadSignalRecord(long id, long powerPlantID, long generatingUnitID)
    {
        try
        {
            SignalRepository sr = new SignalRepository();
            var file = sr.GetRecordFile(powerPlantID, generatingUnitID, id);
        }
        catch (Exception ex)
        {
            // Redirect to timeout page
            Redirect("Timeout");
        }
        return File(file, "binary/RFX", sr.GetRecordName(powerPlantID, generatingUnitID, id) + .rfx");
    }
