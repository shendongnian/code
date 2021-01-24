            public static void Test()
        {
            System.Windows.Media.ImageSource img;
            System.Drawing.Bitmap bmp = (System.Drawing.Bitmap)System.Drawing.Image.FromFile(@"filepath");
           
            //From GDI
            img =  bmp.ToImageSource();
            //From MemoryStream
            img =  bmp.ToImageSource2();
            //Dispose from memory
            bmp.Dispose();
        }
