    catch (Exception ex)
    {
        using (var log = new System.Diagnostics.EventLog("Application") { Source = "MFDBAnalyser" })
        {
            log.WriteEntry(ex.Message);
        }
    }
