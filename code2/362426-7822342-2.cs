        public class ColorHolder
        {
            // construct ColorHolder from Color
            public ColorHolder(Color color)
            {
                Current = color;
            }
            // can assign ColorHolder to Color with implicit conversion
            public static implicit operator Color(ColorHolder value)
            {
                return value.Current;
            }
            // get or set current color
            public Color Current { get; set; }
        }
