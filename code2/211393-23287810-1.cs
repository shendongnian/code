    using Castle.ActiveRecord;
     
    [ActiveRecord("entitycompany")]
    public class CompanyEntity : Entity
    {
        private byte company_type;
        private int comp_id;
     
        [JoinedKey("comp_id")]
        public int CompId
        {
            get { return comp_id; }
            set { comp_id = value; }
        }
     
        [Property("company_type")]
        public byte CompanyType
        {
            get { return company_type; }
            set { company_type = value; }
        }
     
        public new static void DeleteAll()
        {
            DeleteAll(typeof(CompanyEntity));
        }
     
        public new static CompanyEntity[] FindAll()
        {
            return (CompanyEntity[]) FindAll(typeof(CompanyEntity));
        }
     
        public new static CompanyEntity Find(int id)
        {
            return (CompanyEntity) FindByPrimaryKey(typeof(CompanyEntity), id);
        }
    }
     
    [ActiveRecord("entityperson")]
    public class PersonEntity : Entity
    {
        private int person_id;
     
        [JoinedKey]
        public int Person_Id
        {
            get { return person_id; }
            set { person_id = value; }
        }
     
        public new static void DeleteAll()
        {
            DeleteAll(typeof(PersonEntity));
        }
     
        public new static PersonEntity[] FindAll()
        {
            return (PersonEntity[]) FindAll(typeof(PersonEntity));
        }
     
        public new static PersonEntity Find(int id)
        {
            return (PersonEntity) FindByPrimaryKey(typeof(PersonEntity), id);
        }
    }
