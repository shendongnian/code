    class Program
    {
        static void Main(string[] args)
        {
            var exampleObject = new Example();
            exampleObject.PropertyChanging += new PropertyChangingEventHandler(exampleObject_PropertyChanging);
            exampleObject.PropertyChanged += new PropertyChangedEventHandler(exampleObject_PropertyChanged);
            exampleObject.ExampleValue = 123;
            exampleObject.ExampleValue = 100;
        }
        static void exampleObject_PropertyChanging(object sender, PropertyChangingEventArgs e)
        {
            if (e.PropertyName == "ExampleValue")
            {
                int originalValue = ((PropertyChangingCancelEventArgs<int>)e).OriginalValue;
                int newValue = ((PropertyChangingCancelEventArgs<int>)e).NewValue;
                // do not allow the property to be changed if the new value is less than the original value
                if(newValue < originalValue)
                    ((PropertyChangingCancelEventArgs)e).Cancel = true;
            }
        }
        static void exampleObject_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "ExampleValue")
            {
                int previousValue = ((PropertyChangedEventArgs<int>)e).PreviousValue;
                int currentValue = ((PropertyChangedEventArgs<int>)e).CurrentValue;
            }
        }
    }
