        // Level-Class Scope
		static string[] fortune ;
		
        static void Main()
		{
			// Write your main here.
			fortune = new string[6];
			Random rand = new Random();
			int index = rand.Next(fortune.Length);
			Console.WriteLine(fortune[index]);
			Console.ReadLine();
		}
        public static void DisplayFortune(int index)
		{
			Console.WriteLine(fortune[index]);
		}
