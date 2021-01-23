    public class NonNullEmptyInj : ConventionInjection
    {
          protected override bool Match(ConventionInfo c)
          {
            if (c.SourceProp.Name != c.TargetProp.Name
                               || c.SourceProp.Type != c.TargetProp.Type) return false;
            if(c.SourceProp.Value == null) return false;
            if (c.SourceProp.Type == typeof(string) && c.SourceProp.Value.ToString() == string.Empty) return false;
            return true;
           }
    }
