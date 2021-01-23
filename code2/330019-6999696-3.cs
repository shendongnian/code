    abstract class Chip {
        public abstract string Name { get; }
    }
    class Atmega8 : Chip {
        public override string Name {
            get { return "Atmega8 AVR Chip"; }
        }
    }
