    if (!acBlkTbl.Has("COORD2D"))
    {
        _AcDb.Database blkDb = new _AcDb.Database(false, true);
        string blockPath = _AcDb.HostApplicationServices.Current.FindFile("COORD2D.DWG",
                                acCurDb, _AcDb.FindFileHint.Default);
        blkDb.ReadDwgFile(blockPath, System.IO.FileShare.Read, true, "");
        acCurDb.Insert("COORD2D", blkDb, true);
    }
    blkRecId = acBlkTbl["COORD2D"];
