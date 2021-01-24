    public class BattleLogic
    {
        public BattleData battleData;
     
        // as expression body
        public ulong id {get => battleData.id; set => battleData.id = value; }
        // basically the same
        public string name 
        {
            get 
            {
                return battleData.name; 
            }
            set
            {
                battleData.name = value; 
            }
        }
        public int hp {get => battleData.hp; set => battleData.hp = value; }
        public int atk {get => battleData.atk; set => battleData.atk = value; }
    }
    
