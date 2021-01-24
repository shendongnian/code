using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
public static class Comparer {
        public static List<String> Compare<T1, T2>(T1 a, T2 b) {
            var result = new List<String>(); // you can choose to return FieldInfo or values or whatever...
            // you can also use .GetProperties() if you actually want Properties with getters.
            var aFields = typeof(T1).GetFields(BindingFlags.Instance | BindingFlags.Public);
            var bFields = typeof(T2).GetFields(BindingFlags.Instance | BindingFlags.Public);
            var aCommonFields = new List<FieldInfo>();
            var bCommonFields = new List<FieldInfo>();
            Func<IEnumerable<FieldInfo>, FieldInfo, bool> predicate = (other, x) => other.FirstOrDefault(z => z.Name == x.Name && z.FieldType == x.FieldType) != null;
            aCommonFields.AddRange(aFields.Where(x => predicate(bFields, x)));
            bCommonFields.AddRange(bFields.Where(x => predicate(aCommonFields, x)));
            foreach(var aCommonField in aCommonFields) {
                var bCommonField = bCommonFields.First(bField => predicate(new[]{ aCommonField }, bField));
                var aValue = aCommonField.GetValue(a);
                var bValue = bCommonField.GetValue(b);
                if (aValue.Equals(bValue)) {
                    result.Add(aCommonField.Name);
                }
            }
            return result;
        }
    }
Sample usage:
                var a1 = new A { numberOfSales = 42 };
                var b2 = new B { numberOfSales = 42 };
                var commons = Comparer.Compare(a1, b2);
                foreach(var common in commons) {
                    if (common == nameof(A.numberOfSales)) {
                        Console.WriteLine("Number of sales match!");
                    }
                }
