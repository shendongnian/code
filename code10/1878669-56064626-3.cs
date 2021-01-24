    public abstract class Building : ISerializable, IDeserializable {
        // here you define interface, members which every building has
        public abstract string Name { get; }
        public abstract short Id { get; }
        public abstract void Update (); // do staff that this type of building does
        public abstract void ReadMembers (BinaryReader reader);
        public void Write (BinaryWriter writer) {
            writer.Write (Id);
            WriteMembers (writer);
        }
        public abstract void WriteMembers (BinaryWriter writer);
    }
