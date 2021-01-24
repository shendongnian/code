    public static void UpdateUpgradeTable(this Database db, Guid upgradeCode)
    {
        using (View view = db.OpenView("SELECT * FROM `Upgrade`", new object[0]))
        {
            view.Execute();
            using (Record record = view.Fetch())
            {
                record[1] = upgradeCode.ToString("B").ToUpperInvariant();
                view.Replace(record);
            }
    
            db.Commit();
        }
    }
