    public class MyObjectWithADouble {
        public double Element {get; set;} // property is optional, but preferred.
    }
    ...
    var obj = new MyObjectWithADouble();
    obj.Element = 5.0
