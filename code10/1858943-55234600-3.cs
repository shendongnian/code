    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    
    namespace ConsoleApp1
    {
        class MyClass
        {
            protected static Dictionary<string, FieldInfo[]> table = new Dictionary<string, FieldInfo[]>();
            static public int size = 10;
    
            protected char[] grades = new char[size];
    
            public object this[string name, int index]
            {
                get
                {
                    var fieldInfos = table[this.GetType().FullName];
                    return ((Array)fieldInfos.First((x) => x.Name == name).GetValue(this)).GetValue(index);
                }
                set
                {
                    var fieldInfos = table[this.GetType().FullName];
                    ((Array)fieldInfos.First((x) => x.Name == name).GetValue(this)).SetValue(value, index);
                }
            }
    
            static void Main()
            {
                var names = new MyChildClass();
                names[DataColumns.Grades, 1] = 'S';
                names[DataColumns.NameList, 9] = "W.S";
            }
        }
    
        class MyChildClass : MyClass
        {
            private string[] namelist = new string[size];
    
            static MyChildClass()
            {
                var t = typeof(MyChildClass);
                table.Add(t.FullName, t.GetFields(BindingFlags.NonPublic | BindingFlags.Instance));
            }
    
            public MyChildClass()
            {
                for (int i = 0; i < size; i++)
                {
                    namelist[i] = "N. A.";
                    grades[i] = 'F';
                }
            }
        }
    
        static class DataColumns
        {
            public static string NameList = "namelist";
            public static string Grades = "grades";
        }
    }
    
    
