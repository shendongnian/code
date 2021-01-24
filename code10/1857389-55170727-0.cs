        try // Open Connection
        {
            oradbcon = new OracleConnection(yourConnectionStringHere);
            oradbcon.Open();
            OracleGlobalization orainfo = oradbcon.GetSessionInfo();
            orainfo.Language = "AMERICAN"; // Explicitly Set Language
            oradbcon.SetSessionInfo(orainfo);
        }
