    public class Person
    {
        public FullName FullName { get; set; }
        public Person(FullName fullName) { FullName = fullName; }
		
        public IList<IRole> Roles { get; private set; }
        public IRole GetRoleOf<T>() where T: IRole{return Roles.FirstOrDefault(x => x.HasType(typeof(T))); }
        public void AddRole(IRole role) { Roles.Add(role); }
        public bool RemoveRole(IRole role) { return Roles.Remove(role); }
   }
   
    public interface IRole
    {
        bool HasType(Type type);
    }
    public abstract class Role : IRole
    {
        public virtual bool HasType(Type type) { return false; }
    }
    /// <summary>
    /// Base type for any type of role for a person.
    /// </summary>
    public class PersonRole : Role
    {
        public override bool HasType(Type type) { return type.Equals(typeof(PersonRole)); }
    }
	
    /// <summary>
    /// Base type for any type of role for a person.
    /// </summary>
    public class JobRole : Role
    {
        public override bool HasType(Type type) {
            if(type.Equals(GetType())) return true;
            return base.HasType(type);
        }
    }
	    
	/// <summary>
    /// Behavior specific to a salesman
    /// </summary>
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
        protected override void OnFixtureSetUp() {
            _person = new PersonEx(new OneNameFullName("schmuck"));
            // can be a Salesman
            _person.AddRole(new Salesman());
        }
        [Test]
        public void Salesman_CanGet() {
            var salesman = _person.GetRoleOf<Salesman>() as Salesman;
            Assert.That(salesman, Is.Not.Null);
            salesman.NumberOfSales = 50;
            Assert.That(salesman.NumberOfSales, Is.EqualTo(50));
        }
    }
