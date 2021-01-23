	var c = new CodeDomGenerator();
	c.AddNamespace("Example")
		.AddClass("Container")
		.AddMethod(
			MemberAttributes.Public | MemberAttributes.Static,
			(int x) => "Square",
			Emit.@return<int, int>(x => x * x)
		);
	Console.WriteLine(c.GenerateCode(CodeDomGenerator.Language.JScript));
