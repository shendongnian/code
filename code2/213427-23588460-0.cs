        public static string ToInvarianTitleCase(this string self)
        {
            if (string.IsNullOrWhiteSpace(self))
            {
                return self;
            }
            return CultureInfo.InvariantCulture.TextInfo.ToTitleCase(self);
        }
