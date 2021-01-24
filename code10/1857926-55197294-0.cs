    static IEnumerable GetAllMembers(DbContext db, string dbSetName)
            {
                var pi = db.GetType().GetProperty(dbSetName);
                return (IEnumerable)pi.GetValue(db);
            }
