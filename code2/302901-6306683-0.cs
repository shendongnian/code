    public class MyRepository : IMyRepository
    {
        MyEntities db = new MyEntities();
        DateTime now = DateTime.UTCNow;
        
        public void Save() {
            db.SaveChanges();
        }
        
        #region Update / Insert Persons
        
        public void UpdatePerson(Tbl_Person person, int parentId, int userId)
        {
            // let's check if record is in db
            Tbl_Person p = this.GetPersonById(person.PersonId); 
            if(p == null)
                p = new Person(); // person was not found in db
        
            p.FirstName = person.FirstName;
            p.LastName = person.LastName;
        
            // we can now hook up the parent object in 2 ways
            // or set the Id, or attach the hole object
            // NOTE: only choose one line!
            p.MyParent = parentId;
            p.TblParent = this.GetPersonById(parentId);
        
            // update info
            p.UpdateDate = now;
            p.UpdateUser = userId;
        
        
            if(p.PersonId == 0)
            {
                // is it new person in db, so we need to INSERT into the db
                p.CreateDate = now;
                p.CreateUser = userId;
                db.Tbl_Person.AddObject(p);
            }
            else
            {
                // It's an existing person, we do need need to do anything
                // as internally once we assign a new value to the object that
                // come back from the database, EF sets Modified flag on this
            }
         
            // let's save
            this.Save();
        }
        
        #endregion
        
        #region Queries
        
            public Tbl_Person GetPersonById(int personId)
            { 
                return db.Tbl_Person.FirstOrDefault(x => x.PersonId == personId);
            }
        
        #endregion
    
    }
