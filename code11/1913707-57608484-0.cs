    // Auto property which doesn't have any behavior
    // read and write able
    public string charName { get; set; }
    // read only property
    public int currentHP { get; private set; }
    // read only property with a backing field
    private int _maxHP = 100;
    public int maxHP
    {
        get { return _maxHP; }
    }
    // same as before but as expression body
    private int _strength;
    public int strength { get => _strength; }
    // finally a property with additional behaviour 
    // e.g. for the setter make sure the value is never negative 
    private int _defense;
    public int defense
    {
        get { return _defense; }
        set { _defense = Mathf.Max(0, value); }
    }
    
