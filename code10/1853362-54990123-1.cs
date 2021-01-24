    public abstract class DataSize
    {
        protected DataSize(int size)
        {
            if (size < 0) 
                throw new ArgumentOutOfRangeException("Must be greater than zero.", nameof(size));
            Size = size;
        }
    
        public int Size { get; }
    }  
    public abstract class FixedLengthDataItem<TDataSize> 
        where TDataSize : DataSize, new()
    {
        public static TDataSize Data { get; } = new TDataSize();
    
        // a static field here to store the fixed length?
    
        public void LoadFromBytes(byte[] data)
        {
            // Check the fixed length here
            if (data.Length != Data.Size)
            {
                throw new ArgumentException($"Data has size {data.Length} but a size of {Data.Size} was expected.", nameof(data));
            }
    
            DoStuff(data);
        }
    
        protected abstract void DoStuff(byte[] data);
    }
    // Lets say you have 3-4 classes of this size it actually pays of syntax wise
    // Space wise is a different story, you'll need so many instances for this to truly be 
    // worth it but it is an interesting experiment
    public sealed class ItemData345 : DataSize { public ItemDataSize() : base(345) { } }
    
    public sealed class CustomItem : FixedLengthDataItem<ItemData345>
    {
        protected override void DoStuff(byte[] data)
        {
            throw new NotImplementedException();
        }
    }
