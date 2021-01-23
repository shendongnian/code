    interface IVertex 
    {
        int SizeInBytes();
        void SetPointers();
    }
    struct ColorVertex : IVertex
    {
       Vector3 Position;
       Vector4 Color;
       int SizeInBytes
       {
          get { return (3 + 4) * 4; }
       }
       void SetVertexPointers()
       {
           ...
       }
    }
