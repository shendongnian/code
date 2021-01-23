        public static System.Windows.Media.Color ToMediaColor(this System.Drawing.Color color)
        {
            return new System.Windows.Media.Color()
            {
                A = color.A,
                R = color.R,
                G = color.G,
                B = color.B
            };
        }
