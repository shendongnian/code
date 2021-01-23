        void  Foo(Bitmap image)
        {
            for (int y = 0; y < image.Height; ++y)
            {
                for (int x = 0; x < image.Width; ++x)
                {
                    // not very sure about the condition.                   
                    if (image.GetPixel(x, y).A > 0)
                    {
                        image.SetPixel(x,y,Color.White);
                    }
                }
            }
            
        }
