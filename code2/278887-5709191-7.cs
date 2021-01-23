    abstract class Enclosure
    {
        protected abstract Animal GetContents();
        public Animal Contents() { return this.GetContents(); }
    }
    class Aquarium : Enclosure
    {
        protected override Animal GetContents() { return this.Contents(); }
        public new Fish Contents() { ... }
    }
