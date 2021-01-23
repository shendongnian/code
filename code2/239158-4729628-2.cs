        using (BIFDbManager db = new BIFDbManager())
        {
            var output = db.SetCommand(
                "SQL GOES HERE",
                db.Parameter("@Id", 1))
                .ExecuteList<DAL.Model.DirectoryListing>();
            totalrecords = output.Count();
            return output;
        }
