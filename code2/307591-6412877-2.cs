        System.Drawing.Color GetColorValue(decimal value)
        {
            if (value > 0)
            {
                return System.Drawing.Color.Green;
            }
            else if (value < 0)
            {
                return System.Drawing.Color.Red;
            }
            return System.Drawing.Color.White;
        }
