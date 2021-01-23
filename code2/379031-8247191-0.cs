    public interface IThing<out T> where T : IEnumerable<int> {
        T Collection { get; }
    }
    public class Thing : IThing<int[]> {
        public int[] Collection { get; set; }
    }
