    public interface IBaseObject 
    {
        XmlElement Save(IEnumerable<IBaseObject> list);
        IEnumerable<IBaseObject> Load(XmlElement element);
    }
    public interface IBaseObject<T> where T: IBaseObject 
    {
        XmlElement Save(IEnumerable<T> list);
        IEnumerable<T> Load(XmlElement element);
    }
    public class Temperature : IBaseObject<Temperature>, IBaseObject 
    {
        public XmlElement Save(IEnumerable<Temperature> list)
        {
            throw new NotImplementedException("Save in Temperature was called");
        }
        public IEnumerable<Temperature> Load(XmlElement element)
        {
            throw new NotImplementedException("Load in Temperature was called");
        }
        XmlElement IBaseObject.Save(IEnumerable<IBaseObject> list)
        {
            return Save((IEnumerable<Temperature>)list);
        }
        IEnumerable<IBaseObject> IBaseObject.Load(XmlElement element)
        {
            return Load(element);
        }
    }
    public class BaseObjectFile
    {
        public static XmlElement Save(IEnumerable<IBaseObject> list)
        {
            IEnumerable<IBaseObject> safeList= list.DefaultIfEmpty(null);
            IBaseObject obj = safeList.First();
            if (obj != null)
            {
                return obj.Save(list);
            }
            else
            {
                return null;
            }         
        }
        public static IEnumerable<IBaseObject> Load<T>(XmlElement element) where T: IBaseObject 
        {
            IBaseObject proto = new T();
            return obj.Load(proto );
        }
    }
