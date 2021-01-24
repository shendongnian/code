    private blah SaveButton_Click(blah){
        var dt = (CountryWithDatesDataTable)_myDataset.CountryWithDates.Copy();
        for(int i = dt.Count - 1; i >= 0; i--){
          if(!dt[i].SaveThisRow)
            dt[i].Delete(); //mark row deleted
        }
        dt.WriteXml(@"C:\temp\dt.xml")
    }
