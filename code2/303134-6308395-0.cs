    var type = new CodeTypeDeclaration("Extensions");
    type.Attributes = MemberAttributes.Public;
    type.StartDirectives.Add(
        new CodeRegionDirective(CodeRegionMode.Start, "\nstatic"));
    type.EndDirectives.Add(
        new CodeRegionDirective(CodeRegionMode.End, String.Empty));
