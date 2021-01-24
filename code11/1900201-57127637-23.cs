    public abstract class Serializer {
        public abstract byte[] Serialize(object o);
    }
    public class JSONSerializer : Serializer {
        public override byte[] Serialize(object o) { ... }
    }
    public class BinarySerializer : Serializer {
        public override byte[] Serialize(object o) { ... }
    }
    public void DoSomeSerialization(Serializer serializer, Event e) {
        EventStore.Store(serializer.Serialize(e));
    }
