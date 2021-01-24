    public static void Main() {
        var d = new Derived();
        d.CheckCollection("d before AddElement");
        d.AddElement(new GenericObject { i = 2 });
        d.CheckCollection("d after AddElement");
        Console.WriteLine($"ListCount = {Base.ListCount}");
    
        var d2 = new Derived2();
        d2.CheckCollection("d2 before AddElement");
        d2.AddElement(new GenericObject2 { i = 4 });
        d2.AddElement(new GenericObject2 { i = 5 });
        d2.CheckCollection("d2 after AddElement");
        Console.WriteLine($"ListCount = {Base.ListCount}");
    }
    
    public class Base {
        static Dictionary<Type, object> ListReferences = new Dictionary<Type, object>();
        
        public static int ListCount => ListReferences.Count();
    
        protected ReadOnlyCollection<T> RegisterList<T>() {
            var managedList = new List<T>();
            ListReferences.Add(typeof(T), managedList);
            return managedList.AsReadOnly();
        }
    
        public void AddElement<T>(T obj) {
            ((List<T>)ListReferences[typeof(T)]).Add(obj);
        }
    
        public void RemoveElement<T>(T obj) {
            ((List<T>)ListReferences[typeof(T)]).Remove(obj);
        }
    }
    
    public class Derived : Base {
        ReadOnlyCollection<GenericObject> roc;
        public Derived() {
            roc = RegisterList<GenericObject>();
        }
    
        public void CheckCollection(string msg) {
            Console.WriteLine(msg);
            Console.WriteLine(roc.Count());
        }
    }
    
    public class Derived2 : Base {
        ReadOnlyCollection<GenericObject2> roc;
        public Derived2() {
            roc = RegisterList<GenericObject2>();
        }
    
        public void CheckCollection(string msg) {
            Console.WriteLine(msg);
            Console.WriteLine(roc.Count());
        }
    }
    
    public class GenericObject {
        public int i = 0;
    }
    
    public class GenericObject2 {
        public int i = 0;
    }
