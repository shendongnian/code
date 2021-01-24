csharp
        public CoinSide ClientCoinSide { get; set; }
        public CoinSide ServerCoinSide { get; set; }
        public bool UserWin
        {
            get
            {
                return ClientCoinSide == ServerCoinSide;
            }
        }
which can be further simplified to:
csharp
        public CoinSide ClientCoinSide { get; set; }
        public CoinSide ServerCoinSide { get; set; }
        public bool UserWin => ClientCoinSide == ServerCoinSide;
