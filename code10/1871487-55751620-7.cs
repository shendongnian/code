    public class Settings
    {
        private int _currentInt = 7;
        public Settings(int initialInt = 0)
        {
            _currentInt = initialInt;
        }
        public void SaySomething(string something)
        {
            Debug.Log(something);
        }
        public void DoubleCurrentInt()
        {
            CurrentInt *= 2;
        }
        public int GetSquareOfCurrentInt()
        {
            return CurrentInt * CurrentInt;
        }
    }
    
