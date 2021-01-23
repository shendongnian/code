    using (TPMEntities context = new TPMEntities(General.EntityName()))
    {
       context.Attach(SessionHandler.LoginUser);
    
       TPM_PROJECTVERSIONNOTES newNote = context.TPM_PROJECTVERSIONNOTES.CreateObject();
       newNote.TS = System.DateTime.Now;
       newNote.TPM_USER = SessionHandler.LoginUser;
       newNote.NOTES = this.txtTaskNotes.Text;
       TPM_PROJECTVERSION version = (from pv in context.TPM_PROJECTVERSION
                                     where pv.PROJECTID == this.ProjectId && pv.VERSIONID == this.VersionId
                                     select pv).First();
    
       version.TPM_PROJECTVERSIONNOTES.Add(newNote);
       context.SaveChanges();
    }
