    public class DivisionStatus
    {
        public static readonly DivisionStatus None = new DivisionStatus('N');
        public static readonly DivisionStatus Active = new DivisionStatus('A');
        public static readonly DivisionStatus Inactive = new DivisionStatus('I');
        public static readonly DivisionStatus Waitlist = new DivisionStatus('W');
        internal char Value { get; private set; }
        public override string ToString()
        {
            return Value.ToString();
        }
        protected DivisionStatus(char value)
        {
            this.Value = value;
        }
    }
