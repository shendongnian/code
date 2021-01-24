    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    
    namespace Exercise
    {
        class Program
        {
    
            static void Main(string[] args)
            {
                var obj = GetObjectSet();
                //We know obj is an ObjectSet<T> for unknown T
                var t = obj.GetType().GetGenericArguments()[0];
                var parm = Expression.Parameter(typeof(object));
                var objectSet = typeof(ObjectSet<>).MakeGenericType(t);
                var method = typeof(Program).GetMethod("BuildClassItem", BindingFlags.Static | BindingFlags.NonPublic).MakeGenericMethod(t);
    
                var trampoline = Expression.Lambda(
                    Expression.Call(null, method, Expression.Convert(parm,objectSet)), new[] {parm});
                var dele = (Action<object>) trampoline.Compile();
                dele(obj);
                Console.WriteLine("Done");
                Console.ReadLine();
            }
    
            static void BuildClassItem<T>(ObjectSet<T> entities) where T : class
            {
                Console.WriteLine("We made it!");
            }
    
            static object GetObjectSet()
            {
                return new ObjectSet<string>();
            }
        }
    
        internal class ObjectSet<T> where T:class
        {
        }
    }
