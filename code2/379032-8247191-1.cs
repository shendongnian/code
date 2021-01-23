    public class Thing2 : IThing<List<int>> {
        public List<int> Collection { get; set; }
    }
    class Program {
        static void Main() {
            var x = new Thing();
            var y = new Thing2();
            new List<IThing<IEnumerable<int>>> { x, y };
        }
    }
