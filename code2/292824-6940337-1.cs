    public static Multiplicity Multiplicity<TElement>(this IEnumerable<TElement> @this)
    {
        switch (@this.Take(2).Count())
        {
            case 0: return General.Multiplicity.None;
            case 1: return General.Multiplicity.One;
            case 2: return General.Multiplicity.Many;
            default: throw new Exception("WTF‽");
        }
    }
