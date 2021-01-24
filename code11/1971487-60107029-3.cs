        static async Task Main(string[] args)
        {
            dynamic instance = GetClassFromString("Class1");
            Console.WriteLine(instance.GetType().FullName); //NetCoreScripts.Class1
            Console.WriteLine(instance.GetType().Name); //Class1
            Console.WriteLine(instance.Property); //I'm class1
            instance.Property = "Class1 has been changed";
            Console.WriteLine(instance.Property); //Class1 has been changed
            instance.DoSpecialThings(); // Class1 does special things
        }
