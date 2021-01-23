    private void GenerateProperty(CodeMemberProperty e, CodeTypeDeclaration c)
    {
        if ((this.IsCurrentClass || this.IsCurrentStruct) || this.IsCurrentInterface)
        {
            if (e.CustomAttributes.Count > 0)
            {
                this.GenerateAttributes(e.CustomAttributes);
            }
            if (!this.IsCurrentInterface)
            {
                if (e.PrivateImplementationType == null)
                {
                    this.OutputMemberAccessModifier(e.Attributes);
                    this.OutputVTableModifier(e.Attributes);
                    this.OutputMemberScopeModifier(e.Attributes);
                }
            }
            else
            {
                this.OutputVTableModifier(e.Attributes);
            }
            this.OutputType(e.Type);
            this.Output.Write(" ");
            if ((e.PrivateImplementationType != null) && !this.IsCurrentInterface)
            {
                this.Output.Write(this.GetBaseTypeOutput(e.PrivateImplementationType));
                this.Output.Write(".");
            }
            if ((e.Parameters.Count > 0) && (string.Compare(e.Name, "Item", StringComparison.OrdinalIgnoreCase) == 0))
            {
                this.Output.Write("this[");
                this.OutputParameters(e.Parameters);
                this.Output.Write("]");
            }
            else
            {
                this.OutputIdentifier(e.Name);
            }
            this.OutputStartingBrace();
            this.Indent++;
            if (e.HasGet)
            {
                if (this.IsCurrentInterface || ((e.Attributes & MemberAttributes.ScopeMask) == MemberAttributes.Abstract))
                {
                    this.Output.WriteLine("get;");
                }
                else
                {
                    this.Output.Write("get");
                    this.OutputStartingBrace();
                    this.Indent++;
                    this.GenerateStatements(e.GetStatements);
                    this.Indent--;
                    this.Output.WriteLine("}");
                }
            }
            if (e.HasSet)
            {
                if (this.IsCurrentInterface || ((e.Attributes & MemberAttributes.ScopeMask) == MemberAttributes.Abstract))
                {
                    this.Output.WriteLine("set;");
                }
                else
                {
                    this.Output.Write("set");
                    this.OutputStartingBrace();
                    this.Indent++;
                    this.GenerateStatements(e.SetStatements);
                    this.Indent--;
                    this.Output.WriteLine("}");
                }
            }
            this.Indent--;
            this.Output.WriteLine("}");
        }
    }
