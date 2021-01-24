    [Serializable]
    public struct YourStruct
    {
        public Sprite sprite1;
        public Sprite sprite2;
        public Sprite sprite3;
        public Sprite sprite4;
    
        private Sprite[] sprites;
    
        public Sprite Random
        {
            get
            {
                // lazy initialization of array
                if (sprites == null)
                {
                    sprites = new Sprite[] {sprite1, sprite2, sprite3, sprite4};
                }
    
                // pick random
                return sprites[Random.Range(0, sprites.Length)];
            }
        }
    }
