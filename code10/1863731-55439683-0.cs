    public class Implementer : Enforcer
    {
        private readonly string _propy;
        public string Propy
        {
            get => _propy;
            set => throw new InvalidOperationException();
        }
        public Implementer(string propy) { _propy = propy; }
    }
