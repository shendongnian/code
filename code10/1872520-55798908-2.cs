    private void ImportToTempTable()
    {
        // I don't know what this does. I just left it in because it's 
        // part of your original code.
        this.GetProgramInfoForSQLQuery();
        this.GetInstallFolder();
        string config = this._InstallFolder + @"\" + this._Version + @"\" + this._brandName + @".exe.config";
        GetInstanceName(config);
        string filename = "<whatever your file name is>";
        string connStr = "<proprietary conn string parameters>";
        var rowReader = new FileRowReader();
        var rows = rowReader.ReadRows(filename);
        var writer = new SqlRowWriter(connStr);
        writer.WriteRows(rows);
    }
