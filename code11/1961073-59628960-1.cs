    public abstract class Base
    {
        // Shared properties
        public int Id { get; set; }
        public DateTime CreatedDtm { get; set; }
        public string CreatedBy { get; set; }
    }
    
    public class A : Base
    {
        // Individual properties
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
    }
    
    public class B : Base
    {
        // Individual properties
        public string StreetAddress { get; set; }
        public string PostalCode{ get; set; }
        public string City{ get; set; }
    }
    
    class Context : DbContext
    {
        DbSet<Base> Bases { get; set; }
    }
    
    public void AddEntity(Base entity) 
    {
        using (db = new Context())
        {
            db.Bases.Add(entity);
            db.SaveChanges();
        }
    }
