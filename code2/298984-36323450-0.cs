    namespace MySize
    {
        public static class Extensions
        {
            public static Size Parse(this string str)
            {
                try {
                    var a = str.Split(new char[] { 'x' });
                    return new Size() { 
                        Width = int.Parse(a[0]), 
                        Height = int.Parse(a[1]) 
                    };
                }
                catch(Exception) { }
                return Size.nosize;
            }
        }
        public class Size
        {
            public int Width { get; set; }
            public int Height { get; set; }
            public override string ToString()
            {
                return Width.ToString() + "x" + Height.ToString();
            }
            public Size(System.Drawing.Size from)
            {
                Width = from.Width;
                Height = from.Height;
            }
            public Size()
            {
            }
            public static Size nosize = new Size(new System.Drawing.Size(-1, -1));
        }
    //[..]
    }
