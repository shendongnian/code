    class LargestWordsClass
    {
        public LargestWordsClass()
        {
            _LargestWords = new List<String>();
        }
    
        //This says that the variable can be set from the class but read by anyone
        public int LargestWordSize
        {
            get;
            private set;
        }
    
        //This lets users get the list without being able to modify it
        private List<String> _LargestWords;
        public String[] LargestWords
        {
            get
            {
                return _LargestWords.ToArray();
            }
        }
    
        public void FindLargestWord()
        {
            _LargestWords.Clear();
    
            Console.WriteLine("Enter the String: ");
            String buffer = Console.ReadLine();
            String[] splitBuffer = buffer.Split(' ');
    
            LargestWordSize = 0;
            for (int i = 0; i < splitBuffer.Length; i++)
            {
                if (LargestWordSize < splitBuffer[i].Length)
                {
                    LargestWordSize = splitBuffer[i].Length;
                    _LargestWords.Clear();
                    _LargestWords.Add(splitBuffer[i]);
                }
                else if (LargestWordSize == splitBuffer[i].Length)
                {
                    _LargestWords.Add(splitBuffer[i]);
                }
    
                Console.WriteLine("The word is " + splitBuffer[i] + " and the length is " + splitBuffer[i].Length.ToString());
            }
    
            Console.WriteLine("The largest word" + ((_LargestWords.Count > 1) ? "s are" : " is:"));
            for (int i = 0; i < _LargestWords.Count; i++)
            {
                Console.WriteLine(_LargestWords[i]);
            }
        }
    }
