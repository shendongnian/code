    public class Write
    {
        private readonly Action _act;
        public Write(Action act)
        {
            _act = act;
        }
        public void Invoke()
        {
            _act();
        }
        public static Write operator +(Write left, Write right)
        {
            //Do appropriate null-checking.
            var del = (Action)Delegate.Combine(left._act, right._act);
            return new Write(del);
        }
    }
