    public abstract class Student
    {
        public abstract int Age { get; set; }
        public abstract string Name { get; set; }
    }
    public class GoodStudent : Student
    {
        public override int Age { get; set; }
        public override string Name { get; set; }
    }
    public class BadStudent : Student
    {
        public override int Age { get; set; }
        public override string Name { get; set; }
    }
    public class StudentBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var values = (ValueProviderCollection) bindingContext.ValueProvider;
            var dict = values.OfType<DictionaryValueProvider<object>>().Where(v => !(v is RouteDataValueProvider || v is ChildActionValueProvider)).Single();
            var age = (int) dict.GetValue("Age").ConvertTo(typeof (int));
            var name = (string) dict.GetValue("Name").ConvertTo(typeof(string));
            return age > 10 ? (Student) new GoodStudent { Age = age, Name = name } : new BadStudent { Age = age, Name = name };
        }
    }
