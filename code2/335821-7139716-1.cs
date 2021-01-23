    using System;
    using System.Net;
    
    public interface Interface { }
    
    public class Class : Interface { }
    
    public static class TupleHelper<T1>
    {
        public static Tuple<T1> From<TDerived1>(Tuple<TDerived1> tuple)
            where TDerived1 : T1
        {
            return new Tuple<T1>(tuple.Item1);
        }
    }
    
    class Test
    {
        static void Main()
        {
            
            Tuple<Class> tupleWithClass = new Tuple<Class>(new Class());
    
            Tuple<Interface> tupleWithInterfaceIncorrect = 
                TupleHelper<Interface>.From(tupleWithClass);
        }
    }
