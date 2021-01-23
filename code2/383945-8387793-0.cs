    class Program
	{
		static void Main(string[] args)
		{
			var member1 = Syntax.EnumMemberDeclaration(
				identifier: Syntax.Identifier("Member1")
				);
			var declaration = Syntax.EnumDeclaration(
				identifier: Syntax.Identifier("MyEnum"),
				modifiers: Syntax.TokenList(Syntax.Token(SyntaxKind.PublicKeyword)),
				members: Syntax.SeparatedList(member1)
				);
			Console.WriteLine(declaration.Format());
			Console.ReadLine();
		}
	}
