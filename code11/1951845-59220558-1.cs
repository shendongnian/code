    public static Attributes operator +(Attributes x, Attributes y) {
            return new Attributes 
            {
                vitality = x.vitality + y.vitality,
                intelligence = x.intelligence + y.intelligence,
                dexterity = x.dexterity+ y.dexterity,
                agility = x.agility + y.agility
            };
    }
