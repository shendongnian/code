    using(MagickImage image = new MagickImage("test.jpg"))
    {
        image.Distort(DistortMethod.Perspective, new double[] { x0,y0, newX0,newY0, x1,y1,newX1,newY1, x2,y2,newX2,newY2, x3,y3,newX3,newY3 });
        control.Image = image.ToBitmap();
    }
