    // Person Information Model
    public class PersonInfo
    {
        public string Gender { get; set; }
        public int Age { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public int ActivityLevel { get; set; }
        public double Calories { get; set; }
    }
    class Program
    {
        private static PersonInfo info = new PersonInfo();
        public enum InputType { Age, Height, Weight, ActivityLevel }
        static void Main(string[] args)
        {
            // default is null, to tell the application is invalid input
            string _gender = null;
            // keep the user inside this loop as long as the input is invalid.
            while (_gender == null)
            {
                Console.WriteLine("Gender: Male(M)/Female(F)?");
                _gender = GetGender(Console.ReadLine());
                if (_gender == null)
                    Console.WriteLine("Gender has not been specified correctly. Please retype it.");
            }
            // it'll not go out of the loop until the user input is correct.
            info.Gender = _gender;
            // Create an array of inputs that you'll take from the user. 
            InputType[] inputs = { InputType.Age, InputType.Height, InputType.Weight, InputType.ActivityLevel };
            bool hasError = false;
            // Loop over the required inputs, and don't go to the next one until the user input a correct value.
            for (int x = 0; x < inputs.Length; x++)
            {
                double userinput;
                if (hasError)
                    x--;
                if (inputs[x] != InputType.ActivityLevel)
                {
                    Console.WriteLine("{0}? {1} ", inputs[x].ToString(), x);
                    userinput = GetInt(Console.ReadLine(), inputs[x]);
                }
                else
                {
                    Console.WriteLine("How active are you?(Choose by inserting the number)");
                    Console.WriteLine("1.No exercise");
                    Console.WriteLine("2.Little to no exercise");
                    Console.WriteLine("3.Light exercise(1-3 days a week)");
                    Console.WriteLine("4.Moderate exercise(3-5 days a week");
                    Console.WriteLine("5.Heavy exercise(6-7days a week)");
                    // Console.WriteLine("6.Very heavy exercise(Twice per day, extra heavy workouts");
                    userinput = GetInt(Console.ReadLine(), InputType.ActivityLevel);
                    if (userinput >= 0 && userinput < 6)
                    {
                        info.ActivityLevel = (int)userinput;
                        info.Calories = GetCalories(info.Gender, info.Weight, info.Height, info.Age, info.ActivityLevel);
                    }
                    else
                    {
                        //reset input 
                        userinput = -1;
                        Console.WriteLine("Please choose a number between 0 and 5");
                    }
                }
                if (userinput != -1)
                {
                    SetValues((int)userinput, inputs[x]);
                    hasError = false;
                }
                else
                {
                    Console.WriteLine("{0} has not been specified correctly. Please retype it.", inputs[x].ToString());
                    hasError = true;
                }
            }
            // Now, you can show the user info with the calories as well. 
            Console.WriteLine("Your Gender\t\t:\t{0}", info.Gender);
            Console.WriteLine("Your Age\t\t:\t{0}", info.Age);
            Console.WriteLine("Your Height\t\t:\t{0}", info.Height);
            Console.WriteLine("Your Weight\t\t:\t{0}", info.Weight);
            Console.WriteLine("Your Activity Level\t:\t{0}", info.ActivityLevel);
            Console.WriteLine("Your daily calories\t:\t{0} kcal", Math.Round(info.Calories));
            Console.ReadLine();
        }
        public static string GetGender(string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                switch (input.ToLower())
                {
                    case "m":
                    case "male":
                        return "m";
                    case "f":
                    case "female":
                        return "f";
                    default:
                        return null;
                }
            }
            else
            {
                return null;
            }
        }
        public static double GetActivityLevel(int level)
        {
            switch (level)
            {
                case 0:
                    return 1;
                case 1:
                    return 1.2;
                case 2:
                    return 1.375;
                case 3:
                    return 1.55;
                case 4:
                    return 1.725;
                case 5:
                    return 1.9;
                default:
                    return -1;
            }
        }
        public static int GetInt(string input, InputType type)
        {
            if (!string.IsNullOrEmpty(input))
            {
                if (int.TryParse(input, out int result))
                {
                    return result;
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                Console.WriteLine(type.ToString() + " is empty");
                return -1;
            }
        }
        public static void SetValues(int input, InputType type)
        {
            switch (type)
            {
                case InputType.Age:
                    info.Age = input;
                    break;
                case InputType.Weight:
                    info.Weight = input;
                    break;
                case InputType.Height:
                    info.Height = input;
                    break;
            }
        }
        public static double GetCalories(string gender, int weight, int height, int age, int activityLevel)
        {
            if (string.IsNullOrEmpty(gender))
            {
                Console.WriteLine("Gender has not been specified");
                return -1;
            }
            else
            {
                double _cal;
                var _level = GetActivityLevel(activityLevel);
                if (gender == "m")
                    _cal = (66.4730 + (13.7516 * weight) + (5.0033 * height) - (6.7550 * age));
                else
                    _cal = (655.0955 + (9.5634 * weight) + (1.8496 * height) - (4.6756 * age));
                //check first Activity Level, if is it -1 then it's invalid input, those it'll return it.
                return _level != -1 ? _cal * _level : -1;
            }
        }
