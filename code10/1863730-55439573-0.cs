    public class Implementer : Enforcer
    {
        private string _propy;
        public string Propy
        { 
            get
            {
                return _propy;
            }
            set
            {
                // do nothing. so readonly.
            }
        }
        public Implementer(string propy) { _propy = propy; }
    }
