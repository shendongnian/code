    MyVec = MyVec.NormalizeVector();
    public static class Extension
    {
        public static Vector3D NormalizeVector(this Vector3D vec)
        {
            vec.Normalize();
            return vec;
        }
    }
