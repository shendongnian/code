        public UserCredentialMap()
        {
            Id(x => x.Id)
                .Column("UserId")
                .GeneratedBy.Foreign("User");
            HasOne(x => x.User).Constrained();
        }
