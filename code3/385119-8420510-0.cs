    private bool AcceptingTheChanges = false;
    private DataRowView myRecord;
    public DataRowView MyRecord
    {
       get { return myRecord; }
       set {
              if (myRecord != null)
              {
                 // first, see if "AcceptTheChanges" flag is set.
                 // if so, don't try to reissue the AcceptChanges
                 // as that will cause an infinite loop of updating
                 // and getting the current row.
                 if (!AcceptingTheChanges)
                 {
                    // set flag to prevent infinite loop
                    AcceptingTheChanges = true;
                    // NOW, force up the dataviewrow's chain,
                    // to its row, and its table to accept the changes
                    // we've made to the row, but does not do the "UPDATE"
                    // to the final back-end database itself... just the 
                    // in-memory version             
                    myRecord.Row.Table.AcceptChanges();
                    // Now, clear the flag as we're now done with the save
                    AcceptingTheChanges = false;
                 }
              }
              // Now, get the incoming value and re-store into private
              myRecord = value;
              // Finally, raise event that it changed to refresh window...
              RaisePropertyChanged("MyRecord");
           }
    }
