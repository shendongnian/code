    class Program
    {
        static void Main(string[] args)
        {
            var cla = new Sample();
            var propertyInfo = cla.GetType().GetProperty("Samples");
            var addMethod = propertyInfo.PropertyType.GetMethod("Add");
            var samples = propertyInfo.GetValue(cla); // retrieve property value
            var newSample = new Sample();
            addMethod.Invoke(samples, new[] { newSample });
        }
    }
