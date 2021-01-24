    public class EntityModifier : IEntityModifier
    {
        private IContext _context;
    
        public EntityModifier(IContext context)
        {
            _context = context;
        }
    
        public void UpdatePersonAge(Guid id, int age)
        {
            var person = _context.ChangeTracker.Entries<Person>().SingleOrDefault(x => x.Id == id) ??
                         _context.People.Single(x => x.Id == id);
            person.Age = age;
        }
    }
