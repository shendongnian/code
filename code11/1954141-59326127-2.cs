    [Serializable]
    public struct SerializableVector3
    {
        public float X;
        public float Y;
        public float Z;
        public SerializableVector3(Vector3 v)
        {
            X = v.x;
            Y = v.y;
            Z = v.z;
        }
        // And now some magic
        public static implicit operator SerializableVector3 (Vector3 v)
        {
            return new SerializableVector3 (v);
        }
        public static implicit operator Vector3 (SerializableVector3 sv)
        {
            return new Vector3 (sv.X, sv.Y, sv.Z);
        }
    }
