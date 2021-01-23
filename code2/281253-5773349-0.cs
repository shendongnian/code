    class DrawableCube //: Cube
    {
       public Cube TheCube { get; private set; }
       public DrawableCube (Cube c) { TheCube = c; }
       public Texture2D Texture;
       public Shader Shader;
    }
