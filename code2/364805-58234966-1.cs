    public override int CompareTo (Foo rhs) =>
        Bar.CompareTo(rhs.Bar).GetNullIfZero() ??
        Baz.CompareTo(rhs.Baz).GetNullIfZero() ??
        Fuz.CompareTo(rhs.Fuz);
    
    public static class IntExtensions
    {
        public static int? GetNullIfZero(this int i) => i == 0 ? null : (int?)i;
    }
