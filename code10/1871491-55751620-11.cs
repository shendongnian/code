    public static class Vector3Extensions
    {
        public static Vector3 DevideBy(this Vector3 a, Vector3 b)
        {
            return new Vector(a.x / b.x, a.y / b.y, a.z / b.z);
        }
    }
    
