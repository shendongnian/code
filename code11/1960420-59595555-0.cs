Change to return (TEnum)Enum.ToObject(typeof(TEnum), returnInt);. More info [here][1].
    public class Program
    {
        public static void Main()
        {
            var favoriteColor = AskGenericType<Color>("What is your favorite color?");
            Console.WriteLine(favoriteColor);
            var favoriteCar = AskGenericType<Car>("What is your favorite car?");
            Console.WriteLine(favoriteCar);
        }
        enum Color
        {
            Red,
            Blue,
            Yellow
        }
        enum Car
        {
            Volvo,
            Lamborghini,
            Ferrari
        }
        public static TEnum AskGenericType<TEnum>(string message) where TEnum : struct, Enum
        {
            //Display options
            Console.WriteLine(message);
            foreach (var item in Enum.GetValues(typeof(TEnum)))
            {
                Console.WriteLine($"[{(int)item}] {item}");
            }
            var returnInt = TryParseInput();
            while (true)
            {
                if (Enum.IsDefined(typeof(TEnum), returnInt))
                    break;
                //Cannot parse input as one of the choices presented from the Enum
                Console.WriteLine($"Please choose from one of the options.");
                returnInt = TryParseInput();
            }
            return (TEnum)Enum.ToObject(typeof(TEnum), returnInt);
        }
        private static int TryParseInput()
        {
            int returnInt;
            while (!int.TryParse(Console.ReadLine(), out returnInt))
            {
                //Cannot parse input as an integer
                Console.WriteLine($"Selection is not a number. Please try again.");
            }
            return returnInt;
        }
    }
