    class Program
    {
        static void Main(string[] args)
        {
            var smartArray = new SmartArray(10);
            smartArray.SetAtIndex(100, 10);
        }
    }
    public class SmartArray
    {
        private int[] _array;
        public SmartArray()
        {
            _array = new int[5];
        }
        public SmartArray(int length)
        {
            _array = new int[length];
        }
        public void SetAtIndex(int index, int value)
        {
            try
            {
                _array[index] = value;
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public int GetAtIndex(int index)
        {
            try
            {
                return _array[index];
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.ToString());
                return 0;
            }
        }
    }
