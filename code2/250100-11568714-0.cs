        using (TargetDBDataContext db = new TargetDBDataContext())
        {
            db.SomeView.MergeOption = System.Data.Objects.MergeOption.NoTracking;
            return db. SomeView.ToList();
        }
