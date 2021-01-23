    public abstract class Bullet
    {
        public abstract Image Image { get; }
    }
    public class SquareBullet : Bullet
    {
        private static Image _image /* = Load your image */;
        public override Image Image
        {
            get 
            {
                return _image;
            }
        }
    }
