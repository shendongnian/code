    public class Character {
        private bool overpowered = false;
        private int _strength = 0;
        public int Strength
        {
            get { return this._strength; }
            set {
                if (value > 10) { overpowered = true; }
                this._strength = value;
            }
        }
        // [...]
    }
