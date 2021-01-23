    var newApp = Application ();
     //Copy all propery of updatedApplication to  newApp here 
    
                if (newApp .EntityKey == null || newApp .EntityKey.IsTemporary)
                {
                    _DatabaseContext.Applications.AddObject(newApp );
                }
                else
                {
                    _DatabaseContext.Applications.Attach(newApp );
                }
    _DatabaseContext.ObjectStateManager.ChangeObjectState(newApp , System.Data.EntityState.Modified);
