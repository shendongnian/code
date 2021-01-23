    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace ListFromType
    {
        class Program
        {
            static void Main(string[] args)
            {
                var test1 = FlatList(typeof(DateTime));
                var test2 = TypedList<DateTime>(typeof(DateTime));
            }
    
            public static IList<T> TypedList<T>(Type type)
            {
                return FlatList(type).Cast<T>().ToList();
            }
    
            public static IList FlatList(Type type)
            {
                var listType = typeof(List<>).MakeGenericType(new Type[] { type });
                var list = Activator.CreateInstance(listType);
                return (IList) list;
            } 
        }
    }
