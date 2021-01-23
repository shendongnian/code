    public static class CultureInfoExtensions {
      public static IDisposable AsCurrent(this CultureInfo culture) {
        return new CultureRunner(culture);
      }
    }
