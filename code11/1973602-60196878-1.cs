        ...
        public class Class1
        {
                public int IntProperty { get; set; }
                public string StringProperty { get; set; }
        }
        ...
        var instance1 = new Class1();
        var typeofclass1 = typeof(Class1);
        System.Reflection.PropertyInfo[] listProperty = instance1.GetType().GetProperties();
        var somevalue = "1234";
        foreach(var p in listProperty)
        {
                p.SetValue(instance1, Convert.ChangeType(somevalue, p.PropertyType), null);
        }
