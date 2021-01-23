    public class Vector3: Vector2 {
        public Vector3(): base(0, 0) {}
    }
    // Your code:
    Vector2 vector = (Vector3)XmlSerializer.Deserialize(xmlReader);
