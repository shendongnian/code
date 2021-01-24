    public class BaseClass {
        public static void StaticMethod() {
        }
    }
    public class DerivedClass {
        public void DerivedClassMethod() {
            
        }
    }
    //You will not get `StaticMethod` here
    var methods = typeof(DerivedClass).GetMethods(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
