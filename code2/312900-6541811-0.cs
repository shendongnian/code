    using System;
    namespace ConsoleApplication1
    {
        public interface Mass
        {
        }
        public class Kg: Mass
        {
        }
        public interface Length
        {
        }
        public interface M : Length
        {
        }
        public interface M<in T>: M where T: M, Length
        {
        }
        public interface Time
        {
        }
        public interface S : Time
        {
        }
        public interface S<in T> : S where T : S, Time
        {
        }
        public interface IUnit<in M, in L, in T> 
            where M: Mass 
            where L: Length
            where T: Time
        {
        }
        public sealed class Unit<M, L, T>: IUnit<M, L, T>
            where M : Mass
            where L : Length
            where T : Time
        {
            public static Unit<M, L, T>  operator +(Unit<M, L, T> a, Unit<M, L, T> b)
            {
                throw new NotImplementedException();
            }
        }
        public interface Nil: Mass, Length, Time
        {
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                Unit<Nil, M, S<S>> value1 = null;
                Unit<Nil, M, S<S>> value2 = null;
                var result = value1 + value2;
            }
        }
    }
