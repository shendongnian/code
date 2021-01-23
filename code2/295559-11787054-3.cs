    public void WriteLine(string line, Db _db = null)
    {
        Db.Using(_db, db => {
            db.LogLines.Add(new LogLine(line));
            db.SaveChanges();
        });
    }
