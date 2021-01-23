    public interface IRepository
    {
       public ICollection<Person> Find(string name); // tighter, more maintanability    
       public IQueryable<Person> Find(); // full power! but be careful when lazy loading
 
