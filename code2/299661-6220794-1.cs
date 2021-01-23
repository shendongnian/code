    class ColumnGuess
    {
        public string Name { get; set; }
        public Type Type { get; set; }
        public int Samples { get; private set; }
        public void ImproveType(string value)
        {
            if (this.Samples > 10) return;
            this.Samples++;
            float f; bool b; DateTime d; int i;
            if (Single.TryParse(value, out f))
            {
                this.Type = typeof(float);
            }
            else if (Boolean.TryParse(value, out b))
            {
                this.Type = typeof(bool);
            }
            else if (DateTime.TryParse(value, out d))
            {
                this.Type = typeof(DateTime);
            }
            else if (value.Length == 1 && this.Type == null && !Char.IsDigit(value[0]))
            {
                this.Type = typeof(char);
            }
            else if (this.Type != typeof(float) && Int32.TryParse(value, out i))
            {
                this.Type = typeof(int);
            }
        }
    }
