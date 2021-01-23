        public string GetColorName(int r, int g, int b)
        {
            return GetColorName(Color.FromArgb(r, g, b));
        }
        public string GetColorName(Color color)
        {
            foreach (var knownColorName in Enum.GetNames(typeof(KnownColor)))
            {
                var knownColor = Color.FromName(knownColorName);
                if (knownColor.R == color.R && knownColor.G == color.G && knownColor.B == color.B)
                {
                    return knownColorName;
                }
            }
            return color.Name;
        }
