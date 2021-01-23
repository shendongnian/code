    [Flags]
    enum Items
    {
        None = 0x0,
        Foo  = 0x1,
        Bar  = 0x2,
        Baz  = 0x4,
        Boo  = 0x6,
    }
    var value = Items.Foo | Items.Bar;
    var values = value.ToString()
                      .Split(new[] { ", " }, StringSplitOptions.None)
                      .Select(v => (Items)Enum.Parse(typeof(Items), v));
    // This method will always end up with the most applicable values
    value = Items.Bar | Items.Baz;
    values = value.ToString()
                  .Split(new[] { ", " }, StringSplitOptions.None)
                  .Select(v => (Items)Enum.Parse(typeof(Items), v)); // Boo
