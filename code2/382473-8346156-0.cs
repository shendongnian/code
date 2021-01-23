    public static IEnumerable<int> ToBinary(this Bitmap imgToDecode)
    {
        for (int k = 0; k < imgToDecode.Height; k++)
        {
            for (int m = 0; m < imgToDecode.Width; m++)
            {
                yield return (imgToDecode.GetPixel(m, k).R == 0 && 
                              imgToDecode.GetPixel(m, k).G == 0 && 
                              imgToDecode.GetPixel(m, k).B == 0) ? 1 : 0;
            }
        }
    }
