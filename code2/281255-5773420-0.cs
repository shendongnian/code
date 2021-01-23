    public class ClassA : ICloneable
    {
        public string myString { get; set; }
        public object Clone()
        {
            var obj = new ClassA();
            obj.myString = myString;
            return myObj;
        }
    }
