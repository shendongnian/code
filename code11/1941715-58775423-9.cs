        public void CheckPlayerShot(int xCoordinate, int yCoordinate)
        {
            if (shipGrid[xCoordinate, yCoordinate] == Destroyer1 || shipGrid[xCoordinate, yCoordinate] == Destroyer2 || shipGrid[xCoordinate, yCoordinate] == BattleShip)
            {
                Console.WriteLine("HIT!");
                Hit++;
                shotGrid[xCoordinate, yCoordinate] = 'H';
            }
            else
            {
                Console.WriteLine("MISS!");
                Miss++;
                shotGrid[xCoordinate, yCoordinate] = 'M';
            }
        }
