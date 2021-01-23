    catch (Exception ex)
    {
        System.Diagnostics.EventLog log = new System.Diagnostics.EventLog("Application");
        log.Source = "MFDBAnalyser";
        log.WriteEntry(ex.Message);
    }
