    [TestFixture]
    public class RaisesPropertyChangedTest
    {
        [TestCase(typeof(Foo))]
        [TestCase(typeof(Bar))]
        [TestCase(typeof(Baz))]
        public void AllPropertiesRaisePropertyChanged(Type type)
        {
            var target = Activator.CreateInstance(type) as INotifyPropertyChanged;
        
            target.PropertyChanged += this.Target_PropertyChanged;
        
            foreach(var property in type.GetProperties())
            {
                this.AssertRaisesPropertyChanged(target, property);
                // Reset the data captured by the event handler, ready for the next property being tested...
                this.PropertyChangedEventRaised = false;
                this.PropertyChangedEventName = null;
            }
        }
        private void AssertRaisesPropertyChanged(object target, PropertyInfo property)
        {
            // In the case of reference types, setting the property to null should be sufficient
            // to test the property changed behaviour. If the property does argument validation
            // this will have to be a bit smarter :)
            object value = null;
            // In the case of value types, just create a default instance...
            if (property.PropertyType.IsValueType)
                value = Activator.CreateInstance(property.PropertyType);
            property.GetSetMethod().Invoke(target, new object[] { value });
            // Assert that the property changed event was raised...
            this.PropertyChangedEventRaised.Should().BeTrue();
            // Assert that the correct property name was used...
            this.PropertyChangedEventName.Should().Be(property.Name);
        }
        private bool PropertyChangedEventRaised;
        private string PropertyChangedEventName;
    
        private void Target_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            this.PropertyChangedEventRaised = true;
            this.PropertyChangedEventName = e.PropertyName;
        }
    }
