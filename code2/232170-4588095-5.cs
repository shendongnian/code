    public class Enableable : IEnableableAndResettable {
        public bool Enable { get; set; }
        public void Reset() { this.Enable = false; }
    }
    public class Object1 : Enableable { }
    public class Object2 : Enableable { }
