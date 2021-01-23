    public Color HeatMap(float value, float max)
        {
            int r, g, b;
            float val = value / max; // Assuming that range starts from 0
            if (val > 1)
                val = 1;
            if (val > 0.5f)
            {
                val = (val - 0.5f) * 2;
                r = Convert.ToByte(255 * val);
                g = Convert.ToByte(255 * (1 - val));
                b = 0;
            }
            else
            {
                val = val * 2;
                r = 0;
                g = Convert.ToByte(255 * val);
                b = Convert.ToByte(255 * (1 - val));
            }
            return Color.FromArgb(255, r, g, b);
        }
