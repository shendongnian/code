    using System;
    using Xunit;
    using Xunit.Abstractions;
    
    namespace XUnitTestProject1
    {
        public interface IEntityDto
        {
            // Not relevant to this example, how is defined , is just an interface, it ould be removed, if your generic types don't need interface contraints
        }
    
        public interface IRowVersion
        {
            // Not relevant to this example, how is defined , is just an interface, it could be removed, if your generic types don't need interface contraints
        }
    
        public interface IPropertyMappingValue
        {
            // Not relevant to this example, how is defined , is just an interface, it could be removed, if your returned object don't need interface contraints
            string Value { get; set; }
        }
    
        public class PropertyMappingValue : IPropertyMappingValue
        {
            // Not relevant to this example, how is defined , is just an oject, returned by our extension method
            public string Value { get; set; } 
        }
    
        public abstract class EntityBase
        {
            public static IPropertyMappingValue GetPropertyMappingValue<TEntity, TEntityDto>(string name) where TEntity : class, IRowVersion where TEntityDto : class, IEntityDto => EntityExtensions.GetPropertyMappingValue<TEntity, TEntityDto>(name);
        }
    
        // Sample Class
        public class Entity : IRowVersion
        {
        }
    
        // Sample Class
        public class EntityDto : EntityBase, IEntityDto
        {
        }
    
        public static class EntityExtensions
        {
            public static IPropertyMappingValue GetPropertyMappingValue<TEntityDto>(this TEntityDto instance, Type entityType, string name) where TEntityDto : class, IEntityDto
            {
    
                if (!typeof(IRowVersion).IsAssignableFrom(entityType))
                    throw new ArgumentException($"{entityType} do not implements {typeof(IRowVersion)}");
    
                var generic = typeof(GetPropertyMappingValueFactory<,>);
                var typeArgs = new[] { entityType, typeof(TEntityDto) };
                var constructed = generic.MakeGenericType(typeArgs);
    
                var factory = (IGetPropertyMappingValueFactory)Activator.CreateInstance(constructed, name);
    
                return factory.GetPropertyMappingValue();
            }
    
            public static IPropertyMappingValue GetPropertyMappingValue<TEntity, TEntityDto>(string propName) where TEntity : class, IRowVersion where TEntityDto : class, IEntityDto
            {
                //TO DO YOUR JOB HERE TO GTE A VALID RETURNED OBJECT, as this is an example I will retuned a fake
                // THE CODE IS JUST AN EXAMPLE of doing someyhing with the types, but is not relevant for this example
                //
                var foo = typeof(TEntityDto);
                var bar = typeof(TEntity);
                //
    
                return new PropertyMappingValue { Value = propName }; // returning just a fake object
            }
        }
    
        internal class GetPropertyMappingValueFactory<TEntity, TEntityDto> : IGetPropertyMappingValueFactory where TEntity : class, IRowVersion where TEntityDto : class, IEntityDto
        {
            private readonly string _name;
    
            public GetPropertyMappingValueFactory(string name)
            {
                _name = name;
            }
    
            public IPropertyMappingValue GetPropertyMappingValue() => EntityExtensions.GetPropertyMappingValue<TEntity, TEntityDto>(_name);
        }
    
        internal interface IGetPropertyMappingValueFactory
        {
            IPropertyMappingValue GetPropertyMappingValue();
        }
    
        public class UnitTest
        {
            private readonly ITestOutputHelper _console;
    
            public UnitTest(ITestOutputHelper console)
            {
                _console = console;
            }
    
            [Fact]
            public void Test()
            {
                var oneWayOfExecuting = EntityBase.GetPropertyMappingValue<Entity, EntityDto>("Hello world"); //using a abstract base 
    
                _console.WriteLine(oneWayOfExecuting.Value);
    
                var entityDto = new EntityDto();
                var anotherWayOfExecuting = entityDto.GetPropertyMappingValue(typeof(Entity), "Hello world"); //using the extension method
                _console.WriteLine(anotherWayOfExecuting.Value);
    
                Assert.Equal("Hello world", oneWayOfExecuting.Value);
    
                Assert.Equal("Hello world", oneWayOfExecuting.Value);
            }
        }
    }
