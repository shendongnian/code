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
    
    
    public sealed class ItemData345 : DataSize { public ItemDataSize() : base(345) { } }
    
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
    
    public sealed class CustomItem : FixedLengthDataItem<ItemData345>
    {
        protected override void DoStuff(byte[] data)
        {
            throw new NotImplementedException();
        }
    }
