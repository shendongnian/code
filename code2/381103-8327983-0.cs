    List<ProfilePrefillData> badProfiles = new List<ProfilePrefillData>();
    foreach (DataRow row in Data.Rows)
    { 
      ..
      try 
      {
        db.SubmitChanges(ConflictMode.ContinueOnConflict);
      }
      catch (Exception ex)
      {
        // record which are the bad profiles
        badProfiles.Add(profile);
        // Remove the bad profile from items to be added
        db.ProfilePrefillDatas.Remove(profile);
      }
    }
    // Return some information to the user about the bad profiles so that
    // they can be identified, corrected and reimported.
    LogBadProfileData(badProfiles);
