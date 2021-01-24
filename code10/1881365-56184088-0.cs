    namespace Game
    {
        Public class Hero : Character
        {
            int health, max_health, dmg, gold, rüstung;
            string name;
            public Hero(string name, int health, int max_health, int dmg, int rüstung, int gold) : base(name, health, dmg)
            {
                this.name = name;
                this.health = health;
                this.max_health = max_health;
                this.dmg = dmg;
                this.gold = gold;
                this.rüstung = rüstung;
            }
            public void getsDamaged(int d)
            {
                d = d - rüstung;
                if (health - d > 0) health -= d;
                else health = 0;
            }
            public void heal(int h)
            {
                if (health + h < max_health) health += h;
                else health = max_health;
            }
            public int Gold
            {
                get { return gold; }
                set { gold = gold + value; }
            }
            public int Health { get { return this.heath; } }
            public string Name { get { return this.name; } }
            public int Max_health { get { return this.max_health; } }
            public int Dmg { get { return this.dmg; } }
            public int Protection { get; set; }
        }   
    }
