    foreach(oldCount in absenceCount)
    {
        DataRow[] dr = dt.Select("Student ID='" + ID);
        bool updated = false;
        foreach(DataRow row in dr)
        {
          if (!updated && dr["Absence Count"] == absenceCount)
          {
              dr["Absence Count"] = newCount;
              updated = true;
          }
          else
          {
              dr.Delete()
          }
        }
    }
