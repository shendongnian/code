    public class YourClass : ICloneable<YourClass>
    {
        // Constructor logic should be here
        public YourClass Copy() { return this; }        
        public YourClass Clone() { return new YourClass(ID, Name, Dept); }
    }
    interface  IClonable<T>
    {
        T Copy();
        T Clone();
    }
