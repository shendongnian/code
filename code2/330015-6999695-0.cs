    abstract class Chip
    {
        public abstract string Name { get; }
    }
    
    class Amiga8 : Chip
    {
        public override string Name { get { return "Atmega8 AVR Chip"; } }
    }
    
    class Program
    {
    
        static void Main(string[] args)
        {
            Chip chip = new Amiga8();
            Console.WriteLine(chip.Name);
        }
    }
