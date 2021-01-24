    //Your class
    public class Strike : Skill, ISpell {
         public string Description { get; set; } = "Deal 5 damage.";
         public string Name { get; set; } = false;
         public double Damage { get; set; } = false;
         public double CalculateDamage() {
             //Implement
         }
     }
   
    //Create a generic interface to make multiple variants of skills / spells
    public interface ISpell {
        string Name { get; set; }
        string Description{ get; set; }
        //Damage fixed
        double Damage { get; set; }
        //Damage through calculations
        double CalculateDamage();
    }
    //New skill
    public class FireBall : Skill, ISpell {
        public string Description { get; set; } = "Deal 5 damage.";
        public string Name { get; set; } = false;
        public double Damage { get; set; } = false;
        public double CalculateDamage() {
            //Implement
        }
    }
    //Your Player
    public class Player : Entity {
        public int Mana { get; set; }
        public List<ISpell> Skills{ get; set;}
    }
