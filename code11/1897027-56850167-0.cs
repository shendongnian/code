    private static unsafe void YUV2RGBManaged(byte[] YUVData, byte[] RGBData, int width, int height)
        {
            fixed(byte* pRGBs = RGBData, pYUVs = YUVData)
            {
                for (int r = 0; r < height; r++)
                {
                    byte* pRGB = pRGBs + r * width * 3;
                    byte* pYUV = pYUVs + r * width * 2;
    
                    //process two pixels at a time
                    for (int c = 0; c < width; c += 2)
                    {
                        int C1 = pYUV[1] - 16;
                        int C2 = pYUV[3] - 16;
                        int D = pYUV[2] - 128;
                        int E = pYUV[0] - 128;
    
                        int R1 = (298 * C1 + 409 * E + 128) >> 8;
                        int G1 = (298 * C1 - 100 * D - 208 * E + 128) >> 8;
                        int B1 = (298 * C1 + 516 * D + 128) >> 8;
    
                        int R2 = (298 * C2 + 409 * E + 128) >> 8;
                        int G2 = (298 * C2 - 100 * D - 208 * E + 128) >> 8;
                        int B2 = (298 * C2 + 516 * D + 128) >> 8;
    #if true
                        //check for overflow
                        //unsurprisingly this takes the bulk of the time.
                        pRGB[0] = (byte)(R1 < 0 ? 0 : R1 > 255 ? 255 : R1);
                        pRGB[1] = (byte)(G1 < 0 ? 0 : G1 > 255 ? 255 : G1);
                        pRGB[2] = (byte)(B1 < 0 ? 0 : B1 > 255 ? 255 : B1);
    
                        pRGB[3] = (byte)(R2 < 0 ? 0 : R2 > 255 ? 255 : R2);
                        pRGB[4] = (byte)(G2 < 0 ? 0 : G2 > 255 ? 255 : G2);
                        pRGB[5] = (byte)(B2 < 0 ? 0 : B2 > 255 ? 255 : B2);
    #else
                        pRGB[0] = (byte)(R1);
                        pRGB[1] = (byte)(G1);
                        pRGB[2] = (byte)(B1);
    
                        pRGB[3] = (byte)(R2);
                        pRGB[4] = (byte)(G2);
                        pRGB[5] = (byte)(B2);
    #endif
    
                        pRGB += 6;
                        pYUV += 4;
                    }
                }
            }
        }
