    // This is now just a descriptor of the field parameters
    public struct Bitfield
    {
        public int index;
        public int offset;
        public uint mask;
        public Bitfield(int index, int msb, int lsb)
        {
            this.index = index;
            mask = (uint)(((1UL << (msb + 1)) - 1) ^ ((1UL << lsb) - 1));
            offset = lsb;
        }
    }
    // The data is now encapsulated in its own class
    public class DataArray
    {
        public IList<uint> data;
        private Dictionary<string, Bitfield> fields = new Dictionary<string, Bitfield>();
        public DataArray(IList<uint> sourceData)
        {
            // I don't care if this is a copy or reference assignment as long as
            // I use DataArray.data to access the array from now on
            data = sourceData;
        }
        public void AddField(string name, int index, int msb, int lsb)
        {
            fields[name] = new Bitfield(index, msb, lsb);
        }
        public uint Get(string name)
        {
            uint result = 0;
            if(fields.TryGetValue(name, out Bitfield field))
            {
                result = (data[field.index] & field.mask) >> field.offset;
            }
            else
            {
                // throw invalid name
            }
            return result;
        }
        public void Set(string name, uint value)
        {
            if(fields.TryGetValue(name, out Bitfield field))
            {
                data[field.index] = ((value << field.offset) & field.mask) | (data[field.index] & ~field.mask);
            }
            else
            {
                // throw invalid name
            }
        }
    }
