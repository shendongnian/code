        public AccountService() : this(null) { }
        public AccountService(MembershipProvider providera)
        {
            this.provider = providera ?? Membership.Provider;
        }
	
