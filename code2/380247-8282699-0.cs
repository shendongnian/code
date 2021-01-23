    private void FixImage(ref Bitmap field)
    {
        //rotate 45 degrees
        RotateBilinear rot = new RotateBilinear(45);
        var rotField = rot.Apply(field);               //Memory spikes 2mb here
        field.Dispose();
        //crop out unwanted image space
        Crop crop = new Crop(new Rectangle(cropStartX, cropStartY, finalWidth, finalHeight));
        var cropField = crop.Apply(rotField);              //Memory spikes 2mb here
        rotField.Dispose();
        //correct background
        for (int i = 0; i < cropField.Width; i++)
        {
            for (int j = 0; j < cropField.Height; j++)
            {
                if (cropField.GetPixel(i, j).ToArgb() == Color.Black.ToArgb())
                    cropField.SetPixel(i, j, Color.White);
            }
        }                                  //Memory usuage increases 0.5mb by the end
        field = cropField;
    }
