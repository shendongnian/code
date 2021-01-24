    class BindingUser
        {
            public int Uid { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public ObservableCollection<CardData> cardDatas { get; set; }
           
            public BindingUser(int uid, string name)
            {
                Uid = uid;
                FirstName = name;
                LastName = name;
                cardDatas = new ObservableCollection<CardData>()
                {
                    new CardData()
                    {
                        _id = 1,
                        CardName = "card 1",
                    },
                    new CardData()
                    {
                        _id = 2,
                        CardName = "card 2",
                    },
                    new CardData()
                    {
                        _id = 3,
                        CardName = "card 3",
                    },
                };  
            }
        }
