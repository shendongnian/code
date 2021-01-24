    public class Tag
    {
        public string name = null;
        public int dupe = 0;
        public int Tagindex = 0; 
        public int URLindex = 0;
        public Score Score { get; } = new Score() // declare a property of the nested type, and instantiate an object
        public class Type
        {
            public bool isArtist = false;
            public bool isGroup = false;
            public bool isTag = false;
            public bool isURL = false;
        }
        public class Score
        {
           //  0~10, sort them out!
            public bool isRated = false; //make true if user modifies score
            public int Story = 0;
            public int Reality = 0;
            public int Drawing = 0;
            public int memetic = 0;
            public string msg = null;
        }
