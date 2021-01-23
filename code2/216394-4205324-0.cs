    class Message
    {
        [ContractInvariantMethod]
        private void MessageInvariants()
        {
            Contract.Invariant(!string.IsNullOrWhiteSpace(Name));
        }
    
        public Message(string _name)
        {
            Contract.Requires<ArgumentNullException>(!string.IsNullOrWhiteSpace(_name));
            Contract.Ensures(this.Name == _name);
            this.Name = _name;
        }
    
        public string Name { get; private set; }
    }
