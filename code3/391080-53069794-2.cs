    public class Foo
    {
        public Colour colour { get; }
        public Foo(Colour colour) => this.colour = colour;
        public bool Bar()
        {
            if (this.colour == Colour.Red || this.colour == Colour.Blue)
                return true;
            else
                return false;
        }
    }
