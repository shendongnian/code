    class Base {
        protected int Level { get; set; }
    }
  
    class Derived : Base {
        public int Points { get { return this.Level; } set { this.Level = value; } }
    }
