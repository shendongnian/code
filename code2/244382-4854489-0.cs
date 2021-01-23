    public Class Creature
    {
       public int HealthPoints {get; set;}
       public string Name {get; set;}
       public int AttackValue {get; set;}
       public abstract CreatureType Type {get;}
    
       public Creature();
    }
    
    public Class Magical : Creature
    {
       public override CreatureType Type {get{return CreatureType.Magical;}}
       public int Mana {get; set;}
    }
    ...
    if(creatureInstance.Type == CreatureType.Magical) {...}
