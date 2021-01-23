    public sealed class Id<in TDiscriminator>
    {
        private static readonly Guid _idStatic = Guid.NewGuid();
    
        private Id()
        {
        }
    
        public Guid Value
        {
            get { return _idStatic; }
        }
    }
