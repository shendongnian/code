    interface Igloo
    {
        Igloo Clone();
    }
    abstract class Alpha : Igloo
    {
        public abstract Igloo Clone();
    }
    class Bravo : Alpha
    {
        public override Igloo Clone()
        {
            /* implement */
            return null;
        }
    }
