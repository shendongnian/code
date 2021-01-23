    class CarOptions
    {
        public SunroofKind Sunroof { get; set; }
        public SpoilerKind Spoiler { get; set; }
        public TintedWindowKind TintedWindow { get; set; }
        // Note that I split this into two enums - the kind of tinted window
        // (UV-resistant option too maybe?) and color might be different.
        // This is just an example of how such option composition can be done.
        public TintedWindowColor TintedWindowColor { get; set; }
        // In this class, you can also implement additional logic, such as
        // "cannot have spoiler on diesel engine models" and whatever may be required.
    }
    enum SunroofKind
    {
        None,
        Electrical,
        Mechanical
    }
    enum SpoilerKind
    {
        None,
        Standard
    }
    enum TintedWindowKind
    {
        None,
        Standard
    }
    enum TintedWindowColor
    {
        Black,
        Blue
    }
