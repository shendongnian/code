    public class Toto
    {
        public int TheInt { get; set; }
    }
    
    var x = new Toto();
    var propPointer = new PropertyHolder<int,Toto>(x, nameof(Toto.TheInt));
