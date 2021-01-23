    public class MyBinaryReader : BinaryReader {
        public MyBinaryReader(Stream stream) : base(stream) {}
        public new int Read7BitEncodedInt() {
            return base.Read7BitEncodedInt();
        }
    }
    public class MyBinaryWriter : BinaryWriter {
        public MyBinaryWriter(Stream stream) : base(stream) {}
        public new void Write7BitEncodedInt(int i) {
            base.Write7BitEncodedInt(i);
        }
    }
