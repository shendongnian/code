    public interface IVertex
    {
        int SizeInBytes { get; }
        void SetPointers();
    }
    public struct ColorVertex : IVertex
    {
       private Vector3 Position;
       private Vector4 Color;
       public int SizeInBytes
       {
          get { return (3 + 4) * 4; }
       }
       public void SetVertexPointers() // Did you mean SetPointers?
       {
       }
    }
