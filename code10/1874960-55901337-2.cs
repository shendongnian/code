    public class C {
        public void A() {
            foreach (var item in SomeClass.Collection) {}
        }
        
        public void B() {
            var someCollection = SomeClass.Collection;
            foreach (var item in someCollection) {}
        }   
    }
    public static class SomeClass {
        public static List<string> Collection { get; set; }
    }
