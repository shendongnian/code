    public class Cupboard
    {
        public Cupboard(Room parent)
        {
            this.Parent = parent;
        }
        public Room Parent { get; private set; }
    }
