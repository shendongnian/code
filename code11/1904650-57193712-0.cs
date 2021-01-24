    namespace Test
    {
        class Program
        {
            static void Main(string[] args)
            {
                var p1 = new Player();
    
                p1.Health = 5000;
                p1.Armor = "Helmet";
                p1.AddMoney(200);
    
                Console.WriteLine($"Health: { p1.Health }");
    
                var enemy = new Enemy();
    
                enemy.Shoot(p1);
    
                Console.WriteLine($"Health after being shot: {p1.Health}");
            }
        }
    
        class Player
        {
            private string armor;
            private int money;
    
            public int Health { get; set; }
    
            public string Armor
            {
                get => armor;
                set
                {
                    Console.WriteLine("Updating armor.");
                    armor = value;
                }
            }
    
            public int Money { get; private set; }
    
            public void AddMoney(int money)
            {
                // More complex logic here, example: synchronization.
                this.money = money;
            }
        }
    
        class Enemy
        {
            public void Shoot(Player p)
            {
                p.Health -= 500;
            }
        }
    }
