    internal abstract class Unit
    {
        private int Count { get; set; }
        private int Defense { get; set; }
        public int TotalDefense { get { return Count * Defense; } }
        protected Unit(int defense, int count)
        {
            Defense = defense;
            Count = count;
        }
    }
    internal class Tank : Unit
    {
        protected Tank(int count)
            : base(5, count)  // you can use a const variable instead of 5
        {
        }
    }
