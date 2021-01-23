    public int ComputeColorDeltaOptimized(Color color1, Color color2)
    {
        int rDelta = Math.Abs(color1.Red - color2.Red);
        int gDelta = Math.Abs(color1.Green - color2.Green);
        int bDelta = Math.Abs(color1.Black - color2.Black);
        return rDelta + gDelta + bDelta;
    }
