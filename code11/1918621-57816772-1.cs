    public class Partition
    {
        public IEnumerable<string> First;
        public IEnemurable<string> Second;
    };
    var input = new string[]{ "a", "b", "c", "d" };
    var subsets = Getsubsets(input);
    var Partitions = new List<Partition>();
    foreach (var subset in subsets)
    {
        var iPart = new Partition();
        iPart.First = subset;
        iPart.Second = input.Where(iEl => false == subset.Contains(iEl));
        Partitions.Add(iPart);
    }
