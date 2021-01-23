    public abstract class Unit { 
    
        protected Unit(int count) {
          Count=count;
        }
    
        protected int Count { get; private set; }
        protected abstract int Defense {get;}
     
        public int TotalDefense {
          get { return Count*Defense; }
        }
          
    }
    
    public class Tank : Unit {
    
       public Tank(int count) : base(count) {}
    
       protected override int Defense {
         get { return 5; }
       }
    }
    
    public class Troop {
    
       private Unit[] Troops;
    
       public Troop(int soldiers, int tanks, int jets, int forts) {
         Troops = new Unit[] {
                    new Soldier(soldiers),
                    new Tank(tanks),
                    new Jet(jets),
                    new Fort(forts)
                  };
       }
    
       // The using System.Linq you can do
       public int TotalDefense {
         get { return Troops.Sum(x=>x.TotalDefense);}
       }
    }
