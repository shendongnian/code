    [Serializable()]
    public class Vertex : ISerializable
    {
        public Coords pos1, pos2;
        ...
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Pos1", pos1.ToString());
            info.AddValue("Pos2", pos2, typeof(Coords));
        }
        public Vertex(SerializationInfo info, StreamingContext context)
        {
            this.pos1 = Coords.FromString(info.GetValue("Pos1", typeof(string)) as string);
            this.pos2 = (Coords)info.GetValue("Pos2", typeof(Coords));
        }
    }
