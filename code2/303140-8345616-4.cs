      public static void MarkAsVolatileField(this CodeTypeMember typeMember)
      {
         typeMember.StartDirectives.Add(new CodeRegionDirective(
                 CodeRegionMode.Start, System.Environment.NewLine + "\tvolatile"));
         typeMember.EndDirectives.Add(new CodeRegionDirective(
                 CodeRegionMode.End, string.Empty));
      }
