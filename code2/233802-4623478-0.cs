    using System.Linq;
    public class Derived : Base
    {
        public Derived()
            : base(new List<SomeEnum>(Enum.GetValues(typeof(SomeEnum)).OfType<SomeEnum>()))
        {
        }
    }
