    public class Person
    {
        public FullName FullName  { get; set; }
        public IList<IRole> Roles { get; private set; }
    
        public Person(FullName fullName) => FullName = fullName;
    
        public IRole GetRoleOf<T>() where T: IRole => 
            Roles.FirstOrDefault(x => x.HasType(typeof(T)));
        public void AddRole(IRole role)    => Roles.Add(role);
        public bool RemoveRole(IRole role) => Roles.Remove(role);
   }
   
    public interface IRole
    {
        bool HasType(Type type);
    }
    public abstract class Role : IRole
    {
        public virtual bool HasType(Type type) { return false; }
    }
    // Base type for any type of role for a person.
    public class PersonRole : Role
    {
        public override bool HasType(Type type) => type.Equals(typeof(PersonRole));
    }
	
    // Base type for any type of role for a person.
    public class JobRole : Role
    {
        public override bool HasType(Type type) 
        {
            if (type.Equals(GetType())) return true;
            return base.HasType(type);
        }
    }
	    
    // Behavior specific to a salesman
    public class Salesman : JobRole, ISalesman
    {
        public override bool HasType(Type type)
        {
            if (type.Equals(GetType())) return true;
            return base.HasType(type);
        }
        public int NumberOfSales { get; set; }
    }
	    
	[TestFixture]
    public class JobRoleTests : BaseTestFixture
    {
        private PersonEx _person;
        protected override void OnFixtureSetUp() 
        {
            _person = new PersonEx(new OneNameFullName("schmuck"));
            // can be a Salesman
            _person.AddRole(new Salesman());
        }
        [Test]
        public void Salesman_CanGet() 
        {
            var salesman = _person.GetRoleOf<Salesman>() as Salesman;
            Assert.That(salesman, Is.Not.Null);
            salesman.NumberOfSales = 50;
            Assert.That(salesman.NumberOfSales, Is.EqualTo(50));
        }
    }
