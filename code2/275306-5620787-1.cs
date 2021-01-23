    class ConditionalFormat<T> where T : IFormattable {
      public Func<T, Boolean> Predicate { get; set; }
      public String Format { get; set; }
      public static readonly Func<T, Boolean> Tautology = _ => true;
    }
    
    class ConditionalFormatter<T> : Collection<ConditionalFormat<T>>, IFormatProvider, ICustomFormatter
      where T : IFormattable {
      public const String FormatString = "Z";
    
      readonly CultureInfo cultureInfo;
      
      public ConditionalFormatter(IEnumerable<ConditionalFormat<T>> conditionalFormats)
        : this(conditionalFormats, null) { }
    
      public ConditionalFormatter(IEnumerable<ConditionalFormat<T>> conditionalFormats, CultureInfo cultureInfo)
        : base(conditionalFormats.ToList()) {
        this.cultureInfo = cultureInfo;
      }
    
      public Object GetFormat(Type formatType) {
        return formatType == typeof(ICustomFormatter) ? this : null;
      }
      
      public String Format(String format, Object arg, IFormatProvider formatProvider) {
        if (arg.GetType() != typeof(T))
          return HandleOtherFormats(format, arg);
        var formatUpperCase = format.ToUpperInvariant();
        if (formatUpperCase != FormatString)
          return HandleOtherFormats(format, arg);
        
        var value = (T) arg;
        foreach (var conditionalFormat in this)
          if (conditionalFormat.Predicate(value))
            return ((IFormattable) value).ToString(conditionalFormat.Format, cultureInfo);
    
        throw new InvalidOperationException(String.Format("No format matching value {0}.", value));
      }
      
      String HandleOtherFormats(String format, Object arg) {
        var formattable = arg as IFormattable;
        if (formattable != null)
          return formattable.ToString(format, this.cultureInfo);
        else if (arg != null)
          return arg.ToString();
        else
          return String.Empty;
      }
      
    }
