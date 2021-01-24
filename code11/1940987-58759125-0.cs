    private static bool ImageEquals(Bitmap bmpOne, Bitmap bmpTwo)
    {
        for (int i = 0; i < bmpOne.Width; i++)
        {
            for (int j = 0; j < bmpOne.Height; j++)
            {
                if (bmpOne.GetPixel(i, j) != bmpTwo.GetPixel(i, j))
                    return false;
            }
        }
        return true;
    }
