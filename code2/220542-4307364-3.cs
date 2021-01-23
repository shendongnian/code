      class KeyLookupPatternConverter : PatternLayoutConverter
      {
        protected override void Convert(System.IO.TextWriter writer, LoggingEvent loggingEvent)
        {
          string setting;
          //Option is the key name specified in the config file
          if (SomeDictionaryWithYourValues.TryGetValue(Option, out setting))
          {
            writer.Write(setting);
          }
        }
      }
