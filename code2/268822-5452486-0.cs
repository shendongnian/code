    public static class StaticVariables
    {
        public static string _image_source = "ahmed";
        public static string image_source 
        {
            get
            {
                return _image_source;
            }
            set 
            {
                if (!File.Exists(value))
                {
                    throw new FileNotFoundException();
                }
                _image_source = value;
                SetImageData();
            }
        }
        public static Bitmap b = null;
        public static int K_numcolors = 0;
        public static int M_leastbits = 0;
        public static BitmapImage bi = null;
        public static Color[,] RGB_num = null;//orginal colors
        public static Color[,] new_RGB_byte = null;// colors after compression 1
        public static string[, ,] RGB_Bits = null;//original images
        public static string[, ,] new1_RGB_Bits = null;//after compression 1
        private static void SetImageData()
        {
            b = new Bitmap(_image_source);
            RGB_num = new Color[b.Width, b.Height];//orginal colors
            new_RGB_byte = new Color[b.Width, b.Height];// colors after compression 1
            RGB_Bits = new string[b.Width, b.Height, 3];//original images
            new1_RGB_Bits = new string[b.Width, b.Height, 3];//after compression 1
        }
    }
