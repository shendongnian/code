    static void Main(string[] args)
            {
                Console.Write("Enter age");
                string str = Console.ReadLine();
                int MyAge = Convert.ToInt32(str);
                int money = 15000;
                {
                    do
                    {
                        {
                            if (money > 20000 || MyAge < 60)
                            {
                                Console.Write("You are saving little");
                                money = money + 500;
                            }
                            else
                            {
                                Console.Write("You are saving a lot");
                                money = money + 1000;
                            }
                            MyAge++;
                        }
                    }
                    while (money < 40000 && MyAge < 65);
                }
    
                Console.Write("You are retired by the age of " + MyAge + " and you saved " + money + " dollars.");
        }
