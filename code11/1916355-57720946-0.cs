    public static class Vector3Extensions {
        public static Vector3 WithZ(this Vector3 vector, float z) {
            vector.z = z;
            return vector;
        }
    }
