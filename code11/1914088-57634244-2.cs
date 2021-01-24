    void internalCvt(long pixelCount, byte[] bgr, byte[] rgba)
    {
        long byteCount = pixelCount * 4;
        for (long i = 0, offsetBgr = 0; i < byteCount; i += 4, offsetRgb += 3)
        {
            // R
            rgba[i] = bgr[offsetBgr + 2];
            // G
            rgba[i + 1] = bgr[offsetBgr + 1];
            // B
            rgba[i + 2] = bgr[offsetBgr];
            // A
            rgba[i + 3] = 0xFF;
        }
    }
