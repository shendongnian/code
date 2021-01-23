    public async Task WriteLine(string line, Db _db = null)
    {
        await Db.Using(_db, db => {
            db.LogLines.Add(new LogLine(line));
            await db.SaveChangesAsync();
        });
    }
