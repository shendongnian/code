    [IntrinsicFunction("make_float2")]
    public static float2 make_float2(float x, float y)
    {
        return new float2(x, y);
    }
    
    [Kernel]
    private static void ExtractLoop(FloatResidentArray im,
                               ResidentArrayGeneric<float2> res,
                               int size, int yPos, int xPos)
    {
        Parallel2D.For(0, size, 0, size, (y, x) =>
        {
            int i = x + y * size;
            int j = x + xPos + (y + yPos) * size;
            float2 tmp = make_float2(im[j], 0f);
            res[i] = tmp;
        });
    }
