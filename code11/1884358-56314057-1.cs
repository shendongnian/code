 public static void Main()
        {
            int MyAge = 25;
            int money = 15000;
            do
            {
                if (money > 20000 || MyAge < 60)
                {
                    Console.WriteLine("You are saving little");
                    money = money + 500;
                }
                else
                {
                    Console.WriteLine("You are saving a lot");
                    money = money + 1000;
                }
                MyAge++;
            }
            while (MyAge < 65);
            Console.Write("You are retired by the age of " + MyAge + " and you saved " + money + " dollars.");
        }
