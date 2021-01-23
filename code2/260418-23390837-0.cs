     public static class PasswordGenerator
    {
        private const int DefaultMinimum = 6;
        private const int DefaultMaximum = 10;
        private const int UBoundDigit = 61;
        private readonly static char[] PwdCharArray = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789`~!@#$%^&*()-_=+[]{}\\|;:'\",./?".ToCharArray();
        private static readonly RNGCryptoServiceProvider _rng = new RNGCryptoServiceProvider();
        private static int _minSize=DefaultMinimum;
        private static int _maxSize=DefaultMaximum;
        public static int Minimum
        {
            get { return _minSize; }
            set
            {
                _minSize = value;
                if (DefaultMinimum > _minSize)
                {
                    _minSize = DefaultMinimum;
                }
            }
        }
        public static int Maximum
        {
            get { return _maxSize; }
            set
            {
                _maxSize = value;
                if (_minSize >= _maxSize)
                {
                    _maxSize = _minSize + 2;
                }
            }
        }
        public static string Exclusions { get; set; }
        public static bool ExcludeSymbols { get; set; }
        public static bool RepeatCharacters { get; set; }
        public static bool ConsecutiveCharacters { get; set; }
        static PasswordGenerator()
        {
            Minimum = DefaultMinimum;
            Maximum = DefaultMaximum;
            ConsecutiveCharacters = false;
            RepeatCharacters = true;
            ExcludeSymbols = false;
            Exclusions = null;
        }
        private static int GetCryptographicRandomNumber(int lBound, int uBound)
        {
            // Assumes lBound >= 0 && lBound < uBound
            // returns an int >= lBound and < uBound
            uint urndnum;
            var rndnum = new Byte[4];
            if (lBound == uBound - 1)
            {
                // test for degenerate case where only lBound can be returned
                return lBound;
            }
            uint xcludeRndBase = (uint.MaxValue -
                (uint.MaxValue % (uint)(uBound - lBound)));
            do
            {
                _rng.GetBytes(rndnum);
                urndnum = BitConverter.ToUInt32(rndnum, 0);
            } while (urndnum >= xcludeRndBase);
            return (int)(urndnum % (uBound - lBound)) + lBound;
        }
        private static char GetRandomCharacter()
        {
            var upperBound = PwdCharArray.GetUpperBound(0);
            if (ExcludeSymbols)
            {
                upperBound = UBoundDigit;
            }
            int randomCharPosition = GetCryptographicRandomNumber(
                PwdCharArray.GetLowerBound(0), upperBound);
            char randomChar = PwdCharArray[randomCharPosition];
            return randomChar;
        }
        public static string Generate()
        {
            // Pick random length between minimum and maximum   
            var pwdLength = GetCryptographicRandomNumber(Minimum,Maximum);
            var pwdBuffer = new StringBuilder {Capacity = Maximum};
            // Initial dummy character flag
            char lastCharacter  = '\n';
            for (var i = 0; i < pwdLength; i++)
            {
                var nextCharacter = GetRandomCharacter();
                while (nextCharacter == lastCharacter)
                {
                    nextCharacter = GetRandomCharacter();
                }
                if (false == RepeatCharacters)
                {
                    var temp = pwdBuffer.ToString();
                    var duplicateIndex = temp.IndexOf(nextCharacter);
                    while (-1 != duplicateIndex)
                    {
                        nextCharacter = GetRandomCharacter();
                        duplicateIndex = temp.IndexOf(nextCharacter);
                    }
                }
                if ((null != Exclusions))
                {
                    while (-1 != Exclusions.IndexOf(nextCharacter))
                    {
                        nextCharacter = GetRandomCharacter();
                    }
                }
                pwdBuffer.Append(nextCharacter);
                lastCharacter = nextCharacter;
            }
            return pwdBuffer.ToString();
        }
    }
