        using (var db = new OrganizationContext(session))
        {
            byte[] maxRowVersion = db.Users.Max(u => u.RowVersion);
            var newer = db.Users.Where(u => u.RowVersion.IsNewerThan(maxRowVersion)).ToList();
        }
