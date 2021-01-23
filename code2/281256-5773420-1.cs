    public interface ICloneable<T>
    {
        public T Clone();
    }
    public class ClassA : ICloneable<ClassA>
    {
        public string myString { get; set; }
        public ClassA Clone()
        {
            var obj = new ClassA();
            obj.myString = myString;
            return myObj;
        }
    }
