    public void Attack()
            {
                IsEnemyKilled = false;
                Console.WriteLine("Archer attack!");
    			
    			soldiers.foreach(soldier => soldier.BattleCry());
            }
