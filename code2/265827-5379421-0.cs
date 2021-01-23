    if (Settings.Default.MigrateUserSettings)
    {
        Settings.Default.Upgrade();
        Settings.Default.MigrateUserSettings = false;
        /* Custom handling of migrating specific settings (if required) here
           e.g. if any have been renamed or if the possible options have changed. */
        Settings.Default.Save();
    }
