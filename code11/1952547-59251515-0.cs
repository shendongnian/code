    class CopyClass
    {
        public int x;
        public int y;
    
        public CopyClass(FullClass fullObject)
        {
            x = fullObject.x;
            y = fullObject.y;
        }
    
        public static implicit operator CopyClass(FullClass fc) => new CopyClass(fc);
    }
