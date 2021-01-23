    public interface IValidator<T> where T: IObj 
    {
        
    }
    public class PersonValidator : IValidator<Person>
    {
        
    }
    public static class Validators
    {
        public static IValidator<TObject> GetValidator<TObject>(TObject obj)
            where TObject : IObj
        {
            var t = obj.GetType();
            var name = string.Format("{0}.{1}Validator", t.Namespace, t.Name);
            return (IValidator<TObject>) 
                Activator.CreateInstance(Type.GetType(name));
        }
    }
    [TestFixture]
    public class ValidatorsTest
    {
        [Test]
       public void TestPersonValidator()
        {
            var pValidator = Validators.GetValidator(new Person());
        }
    }
