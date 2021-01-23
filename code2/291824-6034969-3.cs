    interface IMyInterface
    {
        int Level { get; set; }
    }
    class MyClass : IMyInterface
    {
        int IMyInterface.Level
        {
            get { return this.Points; }
            set { this.Points = value; }
        }
        public int Points { get; set; }
    }
