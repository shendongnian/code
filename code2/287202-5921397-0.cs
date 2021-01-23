    public interface ISampleObject
    {
        bool IsValid();
    }
    public abstract class SampleObjectBase : ISampleObject
    {
        public virtual bool IsValid()
        {
            var returnValue = true; //VH: Changed value from false to true
            // Self-validation sets the return value.
            var childProperties = this.GetType().GetProperties().Where(pi => typeof(ISampleObject).IsAssignableFrom(pi.PropertyType));
            foreach (var childProperty in childProperties)
            {
                //VH: Here is how you get the value of the property
                var childInstance = (ISampleObject)childProperty.GetValue(this, null);
                if (childInstance.IsValid() != true)                
                {
                     returnValue = false;
                }
            }
            return returnValue;
        }
    }
    public sealed class InnerSampleObject : SampleObjectBase
    {
    }
    public sealed class OuterSampleObject : SampleObjectBase
    {
        //VH: Added this constructor
        public OuterSampleObject()
        {
            DerivedSampleObject = new InnerSampleObject();
        }
        public InnerSampleObject DerivedSampleObject { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            OuterSampleObject c = new OuterSampleObject();
            c.IsValid();
        }
    }
