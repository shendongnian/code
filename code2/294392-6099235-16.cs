    protected internal virtual void VisitSpan(InheritsSpan span) {
      // Set the appropriate base type
      GeneratedClass.BaseTypes.Clear();
      GeneratedClass.BaseTypes.Add(span.BaseClass);
      if (DesignTimeMode) {
        WriteHelperVariable(span.Content, InheritsHelperName);
      }
    }
