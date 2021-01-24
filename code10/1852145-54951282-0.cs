       for (int y = bitmap.Height - 1; y >= 0; y--) {
            for (int x = 0; x < 60; x++) {
                Color color = bitmap.GetPixel(x, y);
                if (color.R != backColor.R || color.G != backColor.G || color.B != backColor.B) {
                    foundContentOnRow = y;
                    break;
                }
            }
        }
