    // just a class which is a gameObject and also has moving behaviour
    // do the same with monster
    public class Human : GameObject, IMoveBehaviour
    {
        public override Update()
        {
            GoMove();
        }
        public void GoMove()
        {
            // human specific logic here
        }
    }
    // This interface describes that some movement 
    // will happen with the implementing class
    public interface IMoveBehaviour
    {
        void GoMove();
    }
