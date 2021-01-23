    public class Model1 : ModelBase
    {
    }
    
    public class ModelBase
    {
    }
    
    public ModelBase Do(Type t)
    {
    	var builder = ObjectFactory.GetInstance(t);
    	return t.GetMethod("Create").Invoke(builder, new object[] { "" }) as ModelBase;
    }
