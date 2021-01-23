        [TestMethod]
        public void PruebaPlayersManager()
        {
            var playersManager = new PlayersManager(2, 5);
                                   
            for (var i = 0; i <= 9; i++)
            {
                var player = new Player
                                 {
                                     Name = i.ToString()
                                 };
                playersManager.Add(player);
            }
        }
