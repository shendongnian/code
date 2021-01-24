            public bool isRed(Color pixelColor)
            {
                if (pixelColor.R > 0x96 && pixelColor.G < 0x14 && pixelColor.B < 0x14)
                {
                    return true;
                }
                return false;
            }
