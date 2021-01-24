    static void Main(string[] args)
    {
        Console.WriteLine("Gender: Male(M)/Female(F)?");
        string gender = Console.ReadLine().ToLower();
        Console.WriteLine("Age?");
        int age = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Height?");
        int height = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Weight in KG?");
        int weightKG = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("How active are you?(Choose by inserting the number)");
        Console.WriteLine("1.No exercise");
        Console.WriteLine("2.Little to no exercise");
        Console.WriteLine("3.Light exercise(1-3 days a week)");
        Console.WriteLine("4.Moderate exercise(3-5 days a week");
        Console.WriteLine("5.Heavy exercise(6-7days a week)");
        Console.WriteLine("6.Very heavy exercise(Twice per day, extra heavy workouts");
        int activityLevel = Convert.ToInt32(Console.ReadLine());
        int calories = 0;
    
        if (gender == "m")
        {
            calories = Convert.ToInt32(66.4730 + (13.7516 * weightKG) + (5.0033 * height) - (6.7550 * age));
            // Console.WriteLine("Your daily calories are: {0}kcal",calories);
        }
        else if (gender == "f")
        {
            calories = Convert.ToInt32(655.0955 + (9.5634 * weightKG) + (1.8496 * height) - (4.6756 * age));
            // Console.WriteLine("Your daily calories are: {0} kcal", calories);
        }
        else
        {
            Console.WriteLine("Please choose correct gender Male(M) or Female(F).");
        }
    
        if (activityLevel == 0)
        {
            calories = Convert.ToInt32(calories * 1);
            Console.WriteLine("Your daily calories are: {0} kcal", calories);
        }
        else if (activityLevel == 1)
        {
            calories = Convert.ToInt32(calories * 1.2);
            Console.WriteLine("Your daily calories are: {0} kcal", calories);
        }
        else if (activityLevel == 2)
        {
            calories = Convert.ToInt32(calories * 1.375);
            Console.WriteLine("Your daily calories are: {0} kcal", calories);
        }
        else if (activityLevel == 3)
        {
            calories = Convert.ToInt32(calories * 1.55);
            Console.WriteLine("Your daily calories are: {0} kcal", calories);
        }
        else if (activityLevel == 4)
        {
            calories = Convert.ToInt32(calories * 1.725);
            Console.WriteLine("Your daily calories are: {0} kcal", calories);
        }
        else if (activityLevel == 5)
        {
            calories = Convert.ToInt32(calories * 1.9);
            Console.WriteLine("Your daily calories are: {0} kcal", calories);
        }
        else
        {
            Console.WriteLine("Please choose a number between 0 and 5");
        }
    }
