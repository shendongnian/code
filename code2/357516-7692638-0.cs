    try { db.SaveChanges(); }
    catch
    {
        db.Set<T>().Remove(obj);
    }
?
