    public FileContentResult DownloadSignalRecord(long id, long powerPlantID, long generatingUnitID)
    {
        SignalRepository sr = new SignalRepository();
        var file = sr.GetRecordFile(powerPlantID, generatingUnitID, id);
            
        HttpContext.Response.AddHeader("Content-Length", file.Length.ToString());
        return File(file, "binary/RFX", sr.GetRecordName(powerPlantID, generatingUnitID, id) + ".rfx");
    }
