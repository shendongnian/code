    using (DatabaseConnection db = new DatabaseConnection()){
        db.InsertIntoDatabase(...);
        db.GetLastInsertID();
        db.GetFromDatabase(...);
    }
