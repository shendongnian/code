    public abstract class Item <T,V>
    {
        public abstract T SerialNumber { get; }
        public V PartNumber { get; }
    }
    public abstract class Toy : Item<int, int>
    {
        public override int SerialNumber => 5; 
        public new int PartNumber => int.Parse(base.PartNumber.ToString()); 
    }
    public abstract class ToyString : Item<string, string>
    {
        public override string SerialNumber => "3";
        public new string PartNumber => "34";
    }
