    public static void MarkAsStatic(this CodeTypeDeclaration class_)
    {
       class_.StartDirectives.Add(new CodeRegionDirective(CodeRegionMode.Start, "\n\tstatic"));
       class_.EndDirectives.Add(new CodeRegionDirective(CodeRegionMode.End, string.Empty));
    }
