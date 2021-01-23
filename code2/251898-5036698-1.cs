    class UserContext
    {
    
        IList<PersistentObject> thingsUserHasChanged;
    
    
        public void Commit()
        {
            foreach(PersistentObject pobj in thingsUserHasChanged)
            {
                if(Security.PermitsUserToCommit(currentUser,pobj)) pobj.Commit();
            }
        }
    }
