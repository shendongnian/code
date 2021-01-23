    public abstract class MagicPerson : IMagicPerson
    {
        protected List<MagicPower> powers;
        public IEnumerable<MagicPower> Powers { get { return powers; } }
    }
