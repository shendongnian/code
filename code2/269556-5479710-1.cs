    public class Application : ApplicationBase, ISerializable
    {
        protected Application(SerializationInfo info, StreamingContext context)
        {
            SerializationInfoEnumerator e = info.GetEnumerator();
            Console.WriteLine("Values in the SerializationInfo:");
            while (e.MoveNext())
            {
                Console.WriteLine("Name={0}, ObjectType={1}, Value={2}", e.Name, e.ObjectType, e.Value);
            }
        }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
        }
    }
