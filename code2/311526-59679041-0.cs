        Bitmap bgpart = null;
        try 
        {
            bgpart = Primary.BackGround.Clone(rect, Primary.BackGround.PixelFormat);
        } 
        catch(Exception e)
        {
            bgpart = Primary.BackGround.Clone(new Rectangle(0, 0, b.Width, b.Height), Primary.BackGround.PixelFormat);
        }
