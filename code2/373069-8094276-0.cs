    private TypeNode AssemblyCompanyAttributeType { get; set; }
    
    public override void BeforeAnalysis()
    {
    	base.BeforeAnalysis();
    
    	this.AssemblyCompanyAttributeType = FrameworkAssemblies.Mscorlib.GetType(
    											Identifier.For("System.Reflection"),
    											Identifier.For("AssemblyCompanyAttribute"));
    }
    
    public override ProblemCollection Check(ModuleNode module)
    {
    	AttributeNode assemblyCompanyAttribute = module.ContainingAssembly.GetAttribute(this.AssemblyCompanyAttributeType);
    	if (assemblyCompanyAttribute == null)
    	{
    		this.Problems.Add(new Problem(this.GetNamedResolution("NoCompanyAttribute"), module));
    	}
    	else
    	{
    		string companyName = (string)((Literal)assemblyCompanyAttribute.GetPositionalArgument(0)).Value;
    		if (!string.Equals(companyName, "FooBar Inc.", StringComparison.Ordinal))
    		{
    			this.Problems.Add(new Problem(this.GetNamedResolution("WrongCompanyName", companyName), module));
    		}
    	}
    
    	return this.Problems;
    }
