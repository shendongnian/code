    public enum CType
    {
        Base,
        Numbers,
        Special,
        German,
        French,
        Russian
    }
    public static readonly Dictionary<CType, string> Collections = new Dictionary<CType, string>
    {
        { CType.Base, "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz" },
        { CType.Numbers, "0123456789" },
        { CType.Special, "°^!\"§$%&/{([)]=}?\\`´*+~'#,;.:-_><|" },
        { CType.German, "ÄÖÜäöü" },
        { CType.French, "éàèùâêîôûäëïüçœ" },
        { CType.Russian, "бвгджзклмнпрстфхцчшщйаэыуояеёюиьъ" }
    };
