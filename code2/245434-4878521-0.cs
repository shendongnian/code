    public abstract class Dice
    {
        protected DieFace[] faces;
        public DieFace RollDie()
        {
            //return random value from faces
        }
        public abstract void FillDieFaces();
    }
    public class RedDie : Dice
    {
        public override void FillDieFaces()
        {
            // assign to faces
        }
    }
    
    public class YellowDie : Dice
    {
        public override void FillDieFaces()
        {
            // assign to faces
        }
    }
