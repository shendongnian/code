    public interface IBaseClass
    {
        XElement _Save(List<IBaseClass> list);
        List<IBaseClass> _Load(XElement structure);
    }
    public abstract class BaseClass<T> where T: IBaseClass, new()
    {
        private static T Prototype {
            get {
                return new T();
            }
        }
        public static XElement Save(List<IBaseClass> list)
        {
            return Prototype._Save(list);
        }
        public static List<IBaseClass> Load(XElement structure)
        {       
            return Prototype._Load(structure);
        }
    }
    
    public class Temperature : BaseClass<Temperature>, IBaseClass
    {
        public float Value { get; set; }
    
        public XElement _Save(List<IBaseClass> list)
        { 
            // do something
        }
        // .. _Load method
    }
