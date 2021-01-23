    public class LetterCounter
    {
        private static readonly string[] _charactersByIndex = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
        
        public string GetStr(int i)
        {
            if (i < _charactersByIndex.Length)
                return _charactersByIndex[i];
            int x = i / (_charactersByIndex.Length - 1) - 1;
            string a = _charactersByIndex[x];
            string b = GetStr(i - (_charactersByIndex.Length - 1));
            return a + b;
        }
    }
}
