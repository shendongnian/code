    var prof = new Profile { ID = 1, Enabled = false };
    // Attach prof as unchanged entity
    context.Profiles.Attach(prof);
    // Get state entry for prof
    ObjectStateEntry entry = context.ObjectStateManager.GetObjectStateEntry(prof);
    // Set only Enabled property to changed
    entry.SetModifiedProperty("Enabled");
    context.SaveChanges();
