    private abstract class Unit  
    {  
        private int _Count;  
        protected readonly const int Defense;
        public int TotalDefense
        { get { return Count * Defense; } }
  
        protected Unit (int count, int defense)
        {
            Defense = defense;
            _Count = count;
        }
    }  
  
    private class Tank : Unit  
    {
        public Tank (int Count)
            : base (Count, 5)
        { }        
    }
    public class Troop
    {
        public IEnumerable<Unit> Units { get; protected set; }
        public Troop (int soldiers, int tanks, int jets, int forts)
        {
            Troops = new Unit[]
            {
                new Soldier (soldiers),
                new Tank (tanks),
                new Jet (jets),
                new Fort (forts)
            }
        }
    }
