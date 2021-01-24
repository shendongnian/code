csharp
        public CoinSide ClientCoinSide { get; set; }
        public CoinSide ServerCoinSide { get; set; }
        public bool ClientWin
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
        public bool ClientWin => ClientCoinSide == ServerCoinSide;
