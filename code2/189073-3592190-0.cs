    public class Comparer
    {
        public bool AreEqual { get; private set; }
    
        public Comparer(myClass x, myClass y)
        {
            var xProperties = x.GetType().GetProperties();
            var yProperties = y.GetType().GetProperties();
    
            var xPropertiesValues = xProperties.Select(pi => pi.GetValue(x, null));
            var yPropertiesValues = yProperties.Select(pi => pi.GetValue(y, null));
    
            AreEqual = xPropertiesValues.SequenceEqual(yPropertiesValues);
        }
    }
