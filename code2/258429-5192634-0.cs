    public class Fu
    {
        int _bar;
        public Fu()
        {
            _bar = 12;
        }
        public void Square()
        {
            _bar *= _bar;
        }
        public override string ToString()
        {
            return _bar.ToString();
        }
    }
