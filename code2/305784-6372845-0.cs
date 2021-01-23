        [Inject]
        public IMembershipProvider Membership { get; set; }
        public Member CurrentMember
        {
            get { return Membership.GetCurrentUser() as Member; }
        }
