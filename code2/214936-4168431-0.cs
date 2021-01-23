    public interface IReadOnly { ... }
    public abstract class Frobber : IReadOnly
    {
        private Frobber() {}
        public class sealed FrobBuilder
        {
            private bool valid = true;
            private RealFrobber real = new RealFrobber();
            public void Mutate(...) { if (!valid) throw ... }
            public IReadOnly Complete { valid = false; return real; }
        }
        private sealed class RealFrobber : Frobber { ... }
    }
