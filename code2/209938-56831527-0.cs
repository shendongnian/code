    public class MyPoco {
        public int x { get; set; }
        public int y { get; set; }
        public int z { get; set; }
        // Add a "Clone" method.
        public MyPoco Clone() {
            return (MyPoco)this.MemberwiseClone();
        }
    }
