    public class BattleLogic
    {
        public BattleData battleData;
     
        // as expression body
        public ulong id 
        {
            get 
            {
                return battleData.id; 
            }
            set 
            {
                battleData.id = value; 
            }
        }
        // basically the same as expression bodies
        public string name { get => battleData.name; set => battleData.name = value; }
        public int hp { get => battleData.hp; set => battleData.hp = value; }
        public int atk { get => battleData.atk; set => battleData.atk = value; }
    }
    
