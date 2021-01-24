    private string lastname;  // backup property
        public string LastName
                {
                    get => lastName;
                    set
                    {
                        lastname = value.TrimAndReduce();
                    }
                }
