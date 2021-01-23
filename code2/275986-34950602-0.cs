    using System;
    using System.Collections.Generic;
    
    namespace ActivitySchedule.Model
    {
        public class NullableEnum<T> where T : struct, IComparable
        {
            public string Display { get; private set; }
    
            public T? Value { get; private set; }
            
            public static implicit operator T?(NullableEnum<T> o)
            {
                return o.Value;
            }
            
            public static implicit operator NullableEnum<T>(T? o)
            {
                return new NullableEnum<T>
                {
                    Display = o?.ToString() ?? "NA",
                    Value = o
                };
            }
    
            private NullableEnum() { }
    
            public static IEnumerable<NullableEnum<T>> GetList()
            {
                var items = new List<NullableEnum<T>>
                {
                    new NullableEnum<T>
                    {
                        Display = "NA",
                        Value = null
                    }
                };
                var values = Enum.GetValues(typeof(T));
    
                foreach (T v in values)
                {
                    items.Add(v);
                }
    
                return items;
            }
        }
    }
