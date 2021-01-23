    public class FooBar
    {
        public bool Problem()
        {
            return Problem(new ProblemArgs());
        }
        public bool Problem(ProblemArgs args)
        {
            //Some logic here
            return true;
        }
    }
    public class ProblemArgs
    {
        public string Name { get; private set; }
        public DateTime Started { get; private set; }
        public ProblemArgs(string name, DateTime started)
        {
            this.Name = name;
            this.Started = started;
        }
        /// <summary>
        /// Default constructor
        /// </summary>
        public ProblemArgs()
        {
            Name = "Foobar";
            Started = DateTime.MaxValue;
        }
    }
