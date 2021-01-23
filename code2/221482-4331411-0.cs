        // Example of a class with internal private field
        public class ExampleClass
        {
            private int example;
        }
        private static FieldInfo _fiExample;
        private int GrabExampleValue(ExampleClass instance)
        {
            // Only need to cache reflection info the first time needed               
            if (_fiExample == null)
            {
                // Cache field info about the internal 'example' private field
                _fiExample = typeof(ExampleClass).GetField("example", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.GetField);
            }
            // Grab the internal property
            return (int)_fiExample.GetValue(instance);
        }
