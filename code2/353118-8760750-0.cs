    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public struct WorldConstants
    {
        public Matrix View;
        public Matrix Projection;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public Color4 [] DiffuseColor;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public Color4[] AmbientColor;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public Vector4[] LightDirection;
        public Vector4 ViewPosition;
    }
