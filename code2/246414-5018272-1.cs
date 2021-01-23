    public class SUT
    {
        private static Practice _practice = null;
        public static Practice getPractice()
        {
            if (_practice == null)
            {
                _practice = new Practice();
            }
            return _practice;
        }
    }
