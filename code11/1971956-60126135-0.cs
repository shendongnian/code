    var Battle = new Task(() =>
            {
                for (int ctr = 1; ctr <= 3; ctr++)
                {
                    Console.WriteLine(" In battle {0}", ctr);
                    Task.Delay(1000).Wait();
                    //Code that makes Ranger win over Assasin
                    Console.WriteLine("{0} attack {1}", Ashe.Ult, Brand.Ult);
                    Random random = new Random();
                    var attack = random.Next(20, 30);
                    Brand.Health -= attack;
                    Console.WriteLine("{0} Damaged {1} by {2}", Ashe.Ult, Brand.Ult, attack);
                    Console.WriteLine("{0} Health: {1}",Brand.Ult, Brand.Health);
                    Console.WriteLine("{0} attack {1}",Brand.Ult, Ashe.Ult);
                    attack = random.Next(5, 10);
                    Ashe.Health -= attack;
                    Console.WriteLine("{0} Damaged {1} by {2}",Brand.Ult, Ashe.Ult,attack);
                    Console.WriteLine("{0} Health: {1}", Ashe.Ult, Ashe.Health);
                    Task.Delay(3000).Wait();
                }
                if(Ashe.Health > Brand.Health)
                {
                    Console.WriteLine("{0} wins", Ashe.Ult);
                    Ashe.Victories++;
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("{0} wins", Brand.Ult);
                    Brand.Victories++;
                    Console.ReadLine();
                }
            }
