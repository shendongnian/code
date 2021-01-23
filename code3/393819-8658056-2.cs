    public interface BaseDrawer
    {
        void Draw(IFruit fruit, Graphics graphics);
    }.
    public class AppleDrawer : BaseDrawer
    {
        public void Draw(IFruit apple, Graphics graphics) { }
    }
    public class BananaDrawer : BaseDrawer
    {
        public void Draw(IFruit banana, Graphics graphics) { }
    }
