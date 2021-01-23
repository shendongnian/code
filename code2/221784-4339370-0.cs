    using (DataContext db = new DataContext())
    {
        var s = db.Area.Single(s => s.ID == 666 && s.Code == 36003 && s.NID == 1);
        s.EndDate = null;
        db.SubmitChanges();
    }
