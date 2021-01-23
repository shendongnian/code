    private void Wrap(Action del) {
      try {
        del();
      } catch (Exception e) {
        Trace.WriteLineIf(ConverterSwitch.TraceVerbose, e);
      }
    }
    
    Wrap(() => { NativeObject.Property1= int.Parse(TextObject.Property1); });
    Wrap(() => { NativeObject.Property2= DateTime.Parse(TextObject.Property2); });
