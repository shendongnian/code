    public abstract class Bullet
    {
        public abstract string Image { get; }
    }
    public class SquareBullet : Bullet
    {
        public override Image Image
        {
            get 
            {
                return "Square";
            }
        }
    }
