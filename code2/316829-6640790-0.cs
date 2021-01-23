    public enum Height
    {
        Short = 0,
        Tall = 1;
    }
    public class Meta
    {
        public Height Height { get; private set; }
        public Meta(Height height)
        {
            if (!Enum.IsDefined(typeof(Height), height))
            {
                throw new ArgumentOutOfRangeException("No such height");
            }
            this.Height = height;
        }
    }
