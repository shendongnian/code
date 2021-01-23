    public static void DeleteDataRecord(int RecordID)
    {
        using(var dc = new ArtworkingDataContext())
        {
            // Delete associated datalabels
            var q = dc.tblArtworkDataLabels.Where(c => c.dataID == RecordID);
            dc.tblArtworkDataLabels.DeleteAllOnSubmit(q);
            dc.SubmitChanges();
    
            // Delete the data record        
            var qq = dc.tblArtworkDatas.Where(c => c.ID == RecordID);
            dc.tblArtworkDatas.DeleteAllOnSubmit(qq);
            dc.SubmitChanges();
        }
    }
