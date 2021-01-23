        public interface IAnimal
    { }
    public class Animal : IAnimal
    {
        public static IAnimal Load(String type)
        {
            IAnimal animal = null;
            switch (type)
            {
                case "Zebra" :
                    animal = new Zebra();
                    break;
                case "Elephant" :
                    animal = new Elephant();
                    break;
                default:
                    throw new Exception();
            }
            return animal;
        }
    }
    public class Zebra : Animal
    {
        public int NrOfStripes { get; set; }
        public static Zebra ZebraFactory()
        {
            return new Zebra();
        }
    }
    public class Elephant : Animal
    {
        public int LengthOfTrunk { get; set; }
    }
