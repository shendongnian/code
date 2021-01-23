    using (var db = new DataClasses1DataContext()) {
        COUNRTY egypt = db.COUNRTies.Where(row => row.NAME == "Egypt").SingleOrDefault();
        if (egypt == null) {
            // "Egypt" is not in the database.
        }
        else {
            var egypt_code = egypt.CODE;
            // Use egypt_code...
        }
    }
