    foreach(var notebook in spSite.Notebooks)
    {
      notebook.IsTopNotebook = true;
    }
    
    try
    {
      spSite.SubmitChanges(ConflictMode.ContinueOnConflict);
    }
    catch(ChangeConflictException ex)
    {
      foreach(ObjectChangeConflict occ in spSite.ChangeConflicts)
      {
        if (((Notebook)occ.Object).Memory > 16)
        {        
          foreach (MemberChangeConflict field in occ.MemberConflicts)
          {
            if (field.Member.Name == "IsTopNotebook")
            {
              field.Resolve(RefreshMode.KeepCurrentValues);
            }
            else
            {
              field.Resolve(RefreshMode.OverwriteCurrentValues);
            }
          }
        }
        else
        {
            occ.Resolve(RefreshMode.KeepCurrentValues);
        }  
      }
      spSite.SubmitChanges();
    }
