    protected void wgSubstancesUsed_UpdateRow(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
    {
        switch (e.Row.DataChanged)
        {
            case Infragistics.WebUI.UltraWebGrid.DataChanged.Added:
                this.InsertRecord(e.Row);
                break;
    
            case Infragistics.WebUI.UltraWebGrid.DataChanged.Modified:
                this.UpdateRecord(e.Row);
                break;
    
            case Infragistics.WebUI.UltraWebGrid.DataChanged.Deleted:
                this.DeleteRecord(e.Row);
                break;
    
        }
    
    }
    
    private void DeleteRecord(UltraGridRow theGridRow)
    {
        //Get the GUID of the record you wish to delete from the grid (for me
        //  the first hidden field of the grid
        Guid thePrimaryKey = new Guid(theGridRow.Cells[0].Value.ToString());
        if (thePrimaryKey != null)
        {
            busClientObject oClient = new busClientObject()
     oClient.Load(thePrimaryKey);  //Get to the individual record, load it into the object
            oClient.DataRow.Delete();  //Mark that record for deletion
            oClient.Save();    //Actually delete it
        }
    
    }
