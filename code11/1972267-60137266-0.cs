    private static byte[] ConvertRasterToColumnFormat(byte[] rasterData, int width, int height)
    {
        int h = height + 7 & -8;
        int w = (width + 7) >> 3;
        int hsmall = h >> 3;
        var result = new byte[h * w];
        for (int y = 0; y < height; y += 8)
        {
            for (int x = 0; x < w; x++)
            {
                // grab 8x8 block of bits
                int i = x + w * y;
                ulong block = rasterData[i];
                if (i + w < rasterData.Length)
                    block |= (ulong)rasterData[i + w] << 8;
                if (i + w * 2 < rasterData.Length)
                    block |= (ulong)rasterData[i + w * 2] << 16;
                if (i + w * 3 < rasterData.Length)
                    block |= (ulong)rasterData[i + w * 3] << 24;
                if (i + w * 4 < rasterData.Length)
                    block |= (ulong)rasterData[i + w * 4] << 32;
                if (i + w * 5 < rasterData.Length)
                    block |= (ulong)rasterData[i + w * 5] << 40;
                if (i + w * 6 < rasterData.Length)
                    block |= (ulong)rasterData[i + w * 6] << 48;
                if (i + w * 7 < rasterData.Length)
                    block |= (ulong)rasterData[i + w * 7] << 56;
                // transpose 8x8
                // https://www.chessprogramming.org/Flipping_Mirroring_and_Rotating#Anti-Diagonal
                ulong t;
                const ulong k1 = 0xaa00aa00aa00aa00;
                const ulong k2 = 0xcccc0000cccc0000;
                const ulong k4 = 0xf0f0f0f00f0f0f0f;
                t = block ^ (block << 36);
                block ^= k4 & (t ^ (block >> 36));
                t = k2 & (block ^ (block << 18));
                block ^= t ^ (t >> 18);
                t = k1 & (block ^ (block << 9));
                block ^= t ^ (t >> 9);
                // write block to columns
                int j = (y >> 3) + h * x;
                result[j] = (byte)block;
                result[j + hsmall] = (byte)(block >> 8);
                result[j + hsmall * 2] = (byte)(block >> 16);
                result[j + hsmall * 3] = (byte)(block >> 24);
                result[j + hsmall * 4] = (byte)(block >> 32);
                result[j + hsmall * 5] = (byte)(block >> 40);
                result[j + hsmall * 6] = (byte)(block >> 48);
                result[j + hsmall * 7] = (byte)(block >> 56);
            }
        }
        return result;
    }
