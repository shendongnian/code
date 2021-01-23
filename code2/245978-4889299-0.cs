    public class ClassBase<T> : IClassType
        where T : IChildPropertyType
    {
        IBasePropertyType IClassType.PropertyName { 
            get {return PropertyName;}
            set {PropertyName = (IChildPropertyType)value;}
        }
        T PropertyName {get;set;}
    }
