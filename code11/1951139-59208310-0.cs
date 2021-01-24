    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System;
    
    #nullable disable
    public static class NullableDisabled3rdPartyClass
    {
        public static object UnclearNullableStateEnumerableAsObject()
        {
            IEnumerable<object> objects = new object[] { 1, 2, 3, null };
            return objects;
        }
    }
    
    #nullable enable
    
    public class Program
    {
        public static void Main()
        {
            foreach (var thing in (IEnumerable)NullableDisabled3rdPartyClass.UnclearNullableStateEnumerableAsObject() ?? Enumerable.Empty<object>())
            {
                object item = thing; //Shows the warning CS8600
                //Console.WriteLine(item.ToString()); //crashes
            }
    
            //does not show any warning but also crashes on thing.toString
            foreach (var thing in (IEnumerable<object>)NullableDisabled3rdPartyClass.UnclearNullableStateEnumerableAsObject() ?? Enumerable.Empty<object>())
            {
                object item = thing; //no warning
                //Console.WriteLine(thing.ToString()); //crashes
            }
    
            //does not help either
            var x = NullableDisabled3rdPartyClass.UnclearNullableStateEnumerableAsObject() as IEnumerable<object>;
            foreach (var thing in x ?? Enumerable.Empty<object>())
            {
                object item = thing; //no warning
                //Console.WriteLine(item.ToString()); //crashes
            }
    
            //shows no warning and does not crash
            foreach (var thing in (IEnumerable)NullableDisabled3rdPartyClass.UnclearNullableStateEnumerableAsObject() ?? Enumerable.Empty<object>())
            {
                if (thing == null) continue;
                object item = thing;
                Console.WriteLine(item.ToString());
            }
        }
    }
