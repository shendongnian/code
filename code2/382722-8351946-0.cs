    // Customs ColorChanged's event parameter.     
    public class ColorChangedEventArgs : EventArgs
    {
        private Color color;
        public ColorChangedEventArgs(Color c)
        {
            color = c;
        }
        public Color GetColor
        {
            get { return color; }
        }
    }
