    public class EnemyLoader
    {
        public void MovePawn() => console.WriteLine("I'm a chess piece");
        public void MoveZombie() => console.WriteLine("Brains");
        public void MoveSlime() => console.WriteLine("Wobbo");
        public Action PickMovement(string moveType)
        {
            switch(moveType)
            {
                case "pawn": return MovePawn;
                case "pawn": return MoveZombie;
                default: return MoveSlime;
            }
        }
            
        public Dictionary<string, EnemySet> LoadEnemies()
        {
            var dataSource = ReadDataFromSomewhere();
            return dataSource.ToDictionary(
                k => k.EnemyName,
                v => new EnemySet
                {
                   EnemyName = v.EnemyName,
                   EnemySpeed = v.EnemySpeed,
                   Move = PickMovement(v.MoveType)
                });
        }
    }
