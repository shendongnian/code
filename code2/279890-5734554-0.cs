    public static class Extensions
    {
        public static Database SetParameter(this Database db, string name, object value)
        {
            if (db == null) throw new ArgumentNullException();
            DbCommand command = db.CurrentCommand; // or whatever
            command.Parameters.AddWithValue(name, value);
            return db;
        }
    }
