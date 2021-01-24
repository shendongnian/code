    public List<Varible> GetVars(string code)
    {
        List<Varible> vars = new List<Varible>();
        Regex dagu = new Regex("var\\s+(\\w+)=\\s*\"([^\"]*)\"");
        Match reg = dagu.Match(code);
        while (reg.Success) 
    	{
            Varible v = new Varible();
            v.vartype = vartype.o_string;
            v.name = reg.Groups[1].Value;
            v.value = reg.Groups[2].Value;
            vars.Add(v);
            reg = reg.NextMatch();
    	}
        return vars;
    }
