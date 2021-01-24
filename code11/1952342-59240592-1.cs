    for (int i = 0; i < cnt; i++)
    {
         xsummag = mag[i] * Math.Cos(ang[i] * Math.PI / 180) + xsummag;
         ysummag = mag[i] * Math.Sin(ang[i] * Math.PI / 180) + ysummag;
    }
