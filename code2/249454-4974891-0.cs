    butRefreshData_Click()
    {
        lock(myLock)
        {
            if (isbusy) {/*tell user*/}
        }
    }
    
    UpdateDatabase(object con)
    {
        lock(myLock)
        {
            if (isbusy) {/*tell user*/ return;}
            else {isbusy = true;}
        }
    
        Updater.RepopulateDatabase();
        lock(myLock)
        {
            isBusy = false;
        }
    }
