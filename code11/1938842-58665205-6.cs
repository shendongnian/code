    sealed class Player
    {
      public string Name { get; private set; }
      public Weapon Weapon { get; set; }
      public int Strength { get; private set; }
      public int BaseDamage { get; private set; }
      public Player(string name, Weapon weapon, int strength, int baseDamage)
      {
        this.Name = name;
        this.Weapon = weapon;
        this.Strength = strength;
        this.BaseDamage = baseDamage;
      }
    }
