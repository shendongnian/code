    internal class First
    {
        public First()
        {
            Second s = new Second(this);
        }
        internal void OnSecondUpdated()
        {
            Console.WriteLine("Done");
            Console.ReadLine();
        }
    }
    internal class Second
    {
        public event Action Updated;
        public Second(First f)
        {
            Updated += f.OnSecondUpdated;
            Third t = new Third(this);
        }
        internal void OnThirdUpdated()
        {
            Updated();
        }
    }
    internal class Third
    {
        public event Action Updated;
        public Third(Second s)
        {
            Updated += s.OnThirdUpdated;
            Updated();
        }
    }
