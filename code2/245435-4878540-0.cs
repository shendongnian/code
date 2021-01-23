    public abstract class Dice
    {
        private DieFace[] faces;
        protected abstract DieFace[] GetDieFaces();
        public void FillDieFaces()
        {
            faces = GetDieFaces();
        }
    }
    public class AnimalDice : Dice
    {
         protected override DieFace[] GetDieFaces()
         {
             return new DieFace[] { DieFace.Panda, DieFace.Unicorn };
         }
    }
