    Foreach(DataRow as row in datable.Rows) {
        var isEmpty = row.ItemArray.All(c => c is DBNull);
        if(!isEmpty) {
            //Your Logic
        }
    }
