    class myImage<T> where T : struct
    {
        // ...
    
        public static myImage<T> CreateFrom<TOther>(myImage<TOther> image) where TOther : struct
        {
            // allocate space for new
            width = image.Width;
            height = image.Height;
            img = new T[width * height];
    
            if (typeof(T) == typeof(byte))
            {
                // in and out = same type? use block copy
                Buffer.BlockCopy(image.Image, 0, img, 0, width * height * Marshal.SizeOf(typeof(T)));
            }
            else
            {
                // else copy image element by element
                for (int counter = 0; counter < width * height; counter++)
                    img[counter] = (T)Convert.ChangeType(image[counter], typeof(T));
            }
        }
    }
