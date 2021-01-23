    abstract class Enclosure
    {
        protected abstract Animal GetContents();
        public Animal Contents() { return this.GetContents(); }
    }
    class Aquarium : Enclosure
    {
        public new Fish Contents() { ... }
        protected override Animal GetContents() { return this.Contents(); }
    }
