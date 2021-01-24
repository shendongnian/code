    using System.Linq;
    public FontFamily[] FontFamilyExt()
    {
      return Enumerable.Range(0, 32).Select(x => new FontFamily(_fnt[x])).ToArray();
    }
