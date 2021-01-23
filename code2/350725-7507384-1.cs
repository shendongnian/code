    internal abstract class Unit 
    { 
        private int Count { get; set; } 
        public abstract int Defense { get; }
        public int TotalDefense { get { return Count * Defense; } }
        protected Unit(int count) 
        { 
            Count = count;
        }
    } 
     
    internal class Tank : Unit 
    {
        override public int Defense { get { return 5; } }
        
        protected Tank(int count) : base(count)
        {
        } 
    }
