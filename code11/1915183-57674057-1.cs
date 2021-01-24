    public interface IFeature<T>
    {
        CustomObject Apply(CustomObject obj, T par);
    }
    
    public class FeatureA : IFeature<FeatureParametersA>
    {
        public CustomObject Apply(CustomObject obj, FeatureParametersA par);
        {
    	    obj.Add(par.SomeText);
    	    return obj;
        }
    }
    
    public class FeatureB : IFeature<FeatureParametersB>
    {
        public CustomObject Apply(CustomObject obj, FeatureParametersB par);
        {
    	    obj.Add(par.SomeNumber.ToString());
    	    return obj;
        }
    }
