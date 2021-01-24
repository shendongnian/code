    [ValueConversion(typeof(IEnumerable<KeyValuePair<string, string>>), typeof(TextBlock))]
    public class EntriesToTextBlockConverter : IValueConverter
    {
      public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
      {
        var result = string.Empty;
        if (value is IEnumerable<KeyValuePair<string, string>> entries)
        {
          var inlines = new List<Inline>();
          entries.ToList().ForEach(
            entry =>
            {
              inlines.Add(new Run("[" + entry.Key + "]:"));
              if (entry.Key.Equals("string", StringComparison.OrdinalIgnoreCase))
                inlines.Add(new Run("[" + entry.Value + "]"));
              else
              {
                inlines.Add(new Run("["));
                inlines.Add(new Bold(new Run("[" + entry.Value + "]")));
                inlines.Add(new Run("]"));
              }
              inlines.Add(new Run(","));
            });
    
          inlines.RemoveAt(inlines.Count - 1);
          var textBlock = new TextBlock();
          textBlock.Inlines.AddRange(inlines);
          return textBlock;
        }
    
        return Binding.DoNothing;
      }
    
      public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
      {
        throw new NotImplementedException();
      }
    }
