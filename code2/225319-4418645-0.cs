    using System;
    using System.Reflection;
    
    // Use constraints which at least make it *slightly* hard to use
    // with the wrong types...
    public class NumericUpDown<T> where T : struct,
        IComparable<T>, IEquatable<T>, IConvertible
    {
        public static readonly T MaxValue = ReadStaticField("MaxValue");
        public static readonly T MinValue = ReadStaticField("MinValue");
        
        private static T ReadStaticField(string name)
        {
            FieldInfo field = typeof(T).GetField(name,
                BindingFlags.Public | BindingFlags.Static);
            if (field == null)
            {
                // There's no TypeArgumentException, unfortunately. You might want
                // to create one :)
                throw new InvalidOperationException
                    ("Invalid type argument for NumericUpDown<T>: " +
                     typeof(T).Name);
            }
            return (T) field.GetValue(null);
        }
    }
    
    class Test
    {
        static void Main()
        {
            Console.WriteLine(NumericUpDown<int>.MaxValue); 
            Console.WriteLine(NumericUpDown<float>.MinValue);
        }
    }
