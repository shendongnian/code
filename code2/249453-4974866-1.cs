    static public class ConcreteList {
        static public List<Type> concrete;
    }
    public class GenericCls<T> {
        static GenericCls() {
            ConcreteList.concrete.Add(typeof(GenericCls<T>));
        }
    }
