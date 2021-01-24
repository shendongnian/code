    [Association(Storage = "_email", ThisKey = "id_mailu", OtherKey = "ID_mailu", IsForeignKey = true)]
            public Email Email
            {
                get { return _email.Entity; }
                set { _email.Entity = value;}
            }
