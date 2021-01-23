        public string ShowBusinessName()
        {
            var attribute = Attribute.GetCustomAttribute(typeof(T), typeof(DescriptionAttribute)) as DescriptionAttribute;
            if (attribute == null)
                return "Unknown business";
            return attribute.Description;
        }
