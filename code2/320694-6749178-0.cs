    public interface IReadOnly {
        Data Value { get; }
    }
    internal interface IWritable : IReadOnly {
        new Data Value { get; set; }
    }
    internal class Impl : IWritable {
        public Data Value { get; set; }
    }
