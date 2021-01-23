    var t = Tuple.Create(1, 2, 3);
    var r = new Ref<Tuple<int, int, int>>(t);
    // share r ...
    r.Value = Tuple.Create(r.Value.Item1, r.Value.Item2, 4);
    ...
    public class Ref<T> {
      public T Value { get; set; }
      public Ref(T value) { Value = value; } 
    }
