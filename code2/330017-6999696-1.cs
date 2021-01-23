    abstract class Chip {
        public abstract string Name { get; }
    }
    class Atmega8 {
        public override string Name {
            get { return "Atmega8 AVR Chip"; }
        }
    }
