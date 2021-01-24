        Envelope env = new Envelope
        {
            Header = new Header
            {
                Security = new Security
                {
                    UsernameToken = new UsernameToken
                    {
                        Username = "abcd",
                        Password = "xyz"
                    }
                }
            },
            Body = new Body
            {
                Request = new Request
                {
                    CorpName = "qw",
                    UserName = "df",
                    LoId = "gh"
                }
            }
        };
