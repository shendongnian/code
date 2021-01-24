        public interface IRGB
        {
    
        }
    
        public struct RGBFloat : IRGB
        {
            public float R { get; }
            public float G { get; }
            public float B { get; }
    
            public RGBFloat(float r, float g, float b)
            {
                R = r;
                G = g;
                B = b;
            }
        }
    
        public struct RGBByte : IRGB
        {
            public byte R { get; }
            public byte G { get; }
            public byte B { get; }
    
            public RGBByte(byte r, byte g, byte b)
            {
                R = r;
                G = g;
                B = b;
            }
        }
    
        public enum TextureFormat
        {
            RGBFloat,
            RGBByte
        }
    
        public class Texture2D
        {
            public int Width { get; }
            public int Height { get; }
            private IRGB[] _buffer; // want it to be able to be either RGBFloat[] or RGBByte[] but nothing else.
    
            public Texture2D(int width, int height, TextureFormat textureFormat)
            {
                Width = width;
                Height = height;
                switch (textureFormat)
                {
                    case TextureFormat.RGBFloat:
                        _buffer = new IRGB[width * height];
                        break;
                    default:
                        _buffer = new IRGB[width * height];
                        break;
                }
            }
    
            public IRGB this[int i]
            {
                get { return (_buffer[i]); }
                set { _buffer[i] = value; }
            }
    
            public IRGB this[int x, int y]
            {
                get { return (_buffer[Width * y + x]); }
                set { _buffer[Width * y + x] = value; }
            }
        }
