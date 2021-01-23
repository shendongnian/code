    using System;
    using System.Linq.Expressions;
    class Program {
        static void Main() {
            var ctor = TypeFactory.GetCtor<int, string, DemoType>();
            var obj = ctor(123, "abc");
            Console.WriteLine(obj.I);
            Console.WriteLine(obj.S);
        }
    }
    class DemoType {
        public int I { get; private set; }
        public string S { get; private set; }
        public DemoType(int i, string s) {
            I = i; S = s;
        }
    }
    static class TypeFactory {
        public static Func<T> GetCtor<T>() { return Cache<T>.func; }
        public static Func<TArg1, T> GetCtor<TArg1, T>() { return Cache<T, TArg1>.func; }
        public static Func<TArg1, TArg2, T> GetCtor<TArg1, TArg2, T>() { return Cache<T, TArg1, TArg2>.func; }
        private static Delegate CreateConstructor(Type type, params Type[] args) {
            if(type == null) throw new ArgumentNullException("type");
            if(args ==  null) args = Type.EmptyTypes;
            ParameterExpression[] @params = Array.ConvertAll(args, Expression.Parameter);
            return Expression.Lambda(Expression.New(type.GetConstructor(args), @params), @params).Compile();
        }
        private static class Cache<T> {
            public static readonly Func<T> func = (Func<T>)TypeFactory.CreateConstructor(typeof(T));
        }
        private static class Cache<T, TArg1> {
            public static readonly Func<TArg1, T> func = (Func<TArg1, T>)TypeFactory.CreateConstructor(typeof(T), typeof(TArg1));
        }
        private static class Cache<T, TArg1, TArg2> {
            public static readonly Func<TArg1, TArg2, T> func = (Func<TArg1, TArg2, T>)TypeFactory.CreateConstructor(typeof(T), typeof(TArg1), typeof(TArg2));
        }
    }
