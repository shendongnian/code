    public interface IThing
    {
        IEnumerable<int> Collection { get; }
    }
    public class Thing : IThing
    {
        public int[] Collection { get; set; }
        IEnumerable<int> IThing.Collection { get { return this.Collection; } }
    }
