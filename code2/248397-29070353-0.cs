    public interface IControllable
    {
        void Move(int step);
        void Backward(int step);
    }
    public interface ITurnable
    {
       void TurnLeft(float angle);
       void TurnRight(float angle);
    }
    public class Airplane : IControllable, ITurnable
    {
       void Move(int step)
       {
           // TODO: Implement code here...
       }
       void Backward(int step)
       {
           // TODO: Implement code here...
       }
       void TurnLeft(float angle)
       {
           // TODO: Implement code here...
       }
       void TurnRight(float angle)
       {
           // TODO: Implement code here...
       }
    }
