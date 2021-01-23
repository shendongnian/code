    public class MyArrayClass
    {
        private int[][] _master = new int[10][];
        private int[] _current = new int[3];
        private int _currentCount, _masterCount;
    
        public void Add(int number)
        {
            _current[_currentCount] = number;
            _currentCount += 1;
            if (_currentCount == _current.Length)
            {
                Array.Copy(_current,0,_master[_masterCount],0,3);
                _currentCount = 0;
                _current = new int[3];
                _masterCount += 1;
                if (_masterCount == _master.Length)
                {
                    int[][] newMaster = new int[_master.Length + 10][];
                    Array.Copy(_master, 0, newMaster, 0, _master.Length);
                    _master = newMaster;
                }
            }
        }
    
        public int[][] GetMyArray()
        {
            return _master;
        }
    
        public int[] GetMinorArray(int index)
        {
            return _master[index];
        }
    
        public int GetItem(int MasterIndex, int MinorIndex)
        {
            return _master[MasterIndex][MinorIndex];
        }
    }
