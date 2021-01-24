    class MyInfo
    {
        public DateTime StartTime {get; set;}
        public DateTime EndTime {get; set;}
        ... // other info properties you actually plan to use
        // Constructors:
        public MyInfo() { } // default constructor
        public MyInfo(ThirdParyNameSpace.Info info)
        {
            this.StartTime = info.StartTime.ToDateTime();
            this.EndTime = info.EndTime.ToDateTime();
            ...
        }
    }
