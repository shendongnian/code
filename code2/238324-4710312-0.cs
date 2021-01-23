    public abstract class MyObject {
     protected string common1; 
     protected string common2;
    }
    
    public class MyType1 : MyObject {
     string type1unique1; 
     string type1unique2;
    }
    
    public class MyType2 : MyObject {
     string type2unique1; 
     string type2unique2;
    }
    IDictionary<int, MyObject> objects = new Dictionary<int, MyObject>();
    objects[1] = new MyType1();
    objects[1].common1
    if(objects[1] is MyType1) {
    	((MyType1)objects[1]).type1unique1
    }
