    public class Program
    {
        public static void Main()
        {
            //Arrange
            IConfiguration mock = new MockConfiguration();
            //Act
            var obj = mock.GetValid<SimpleObject>();
            //Assert;
            Console.WriteLine(obj.GetType().IsAssignableFrom(typeof(SimpleObject)));
            Console.ReadLine();
        }
        
    }
    public static class ValidationExtensions
    {
        public static T GetValid<T>(this IConfiguration configuration) where T : new()
        {
            var obj = configuration.Get<T>();
            Validator.ValidateObject(obj, new ValidationContext(obj), true);
            return obj;
        }
    }
    public interface IConfiguration
    {
        T Get<T>() where T : new();
    }
    public class MockConfiguration : IConfiguration
    {
        public T Get<T>() where T : new()
        {
            T result = new T();
            return result;
        }
    }
    public class SimpleObject
    {
    }
