    public void SomeMethod() {
        yourOpenDatabase.ObjectAppended += ObjAppendHandler;
    }
    
    public void ObjAppendHandler(Database db, CADAccess.FillerObject fo) {
        //Insert code to handle your event...
    }
