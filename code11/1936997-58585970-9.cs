    public class BaseClass {
        public static void StaticMethodInBaseClass() {
        }
    }
    public class DerivedClass {
        public void DerivedClassMethod() {
        }
    }
    //You will not get `StaticMethodInBaseClass` here
    var methods = typeof(DerivedClass).GetMethods(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
