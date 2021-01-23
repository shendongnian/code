    public class SpacesArray : List<Space>
    {
        public Space this[Color c, int i]
        {
            get
            {
                return this[c == Color.White ? i : this.Count - i - 1];
            }
            set
            {
                this[c == Color.White ? i : this.Count - i - 1] = value;
            }
        }
    }
