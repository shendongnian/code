    private static int _skillMax; // Fields are automatically initialized to the default
                                 // value of their type. For `int` this is `0`.
    public static int SkillMax
    {
        get { return _skillMax; }
        set {
            _skillMax = value;
            _skill = _skillMax; // Automatically initializes the initial value of Skill.
                                // At program start up you only need to set `SkillMax`.
        }
    }
    private static int _skill;
    public static int Skill
    {
        get { return _skill; }
        set { _skill = Math.Min(value, _skillMax); }
    }
