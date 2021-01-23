    [TestFixture]
    public class PropertiesThrowWhenFrozenTest
    {
        [TestCase(typeof(Foo))]
        [TestCase(typeof(Bar))]
        [TestCase(typeof(Baz))]
        public void AllPropertiesThrowWhenFrozen(Type type)
        {
            var target = Activator.CreateInstance(type) as IFreezable;
            target.Freeze();
               
            foreach(var property in type.GetProperties())
            {
                this.AssertPropertyThrowsWhenChanged(target, property);
            }
        }
        private void AssertPropertyThrowsWhenChanged(object target, PropertyInfo property)
        {
            // In the case of reference types, setting the property to null should be sufficient
            // to test the behaviour...
            object value = null;
            // In the case of value types, just create a default instance...
            if (property.PropertyType.IsValueType)
                value = Activator.CreateInstance(property.PropertyType);
            Action setter = () => property.GetSetMethod().Invoke(target, new object[] { value });
            // ShouldThrow is a handy extension method of the FluentAssetions library...
            setter.ShouldThrow<InvalidOperationException>();
        }
    }
