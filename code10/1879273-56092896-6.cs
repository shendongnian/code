        class Player
        {
            public string Name { get; set; }
            public int Score { get; set; }
            public override string ToString()
            {
                return $"{Name,-15}: {Score,4}";
            }
        }
