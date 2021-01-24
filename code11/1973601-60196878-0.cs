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
                var typeofproperty = typeofclass1.GetProperty(p.Name);
                typeofproperty.SetValue(instance1, Convert.ChangeType(somevalue, typeofproperty.PropertyType), null);
        }
