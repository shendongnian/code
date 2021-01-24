public static T AddRegion<T>(this T node, string regionName) where T : SyntaxNode
{
	return node
		// inserts #region RegionName before node
		.WithLeadingTrivia(node.GetLeadingTrivia().Insert(0, GetRegionLeadingTrivia(regionName)))
		// inserts #endregion after node
		.WithTrailingTrivia(node.GetTrailingTrivia().Add(GetRegionTrailingTrivia()));
}
public static SyntaxTrivia GetRegionLeadingTrivia(string regionName)
{
	return SyntaxFactory.Trivia(
		SyntaxFactory
			.RegionDirectiveTrivia(true)
			.WithEndOfDirectiveToken(
				SyntaxFactory.Token(
					SyntaxFactory.TriviaList(SyntaxFactory.PreprocessingMessage(regionName)),
					SyntaxKind.EndOfDirectiveToken,
					SyntaxFactory.TriviaList())));
}
public static SyntaxTrivia GetRegionTrailingTrivia()
{
	return SyntaxFactory.Trivia(SyntaxFactory.EndRegionDirectiveTrivia(true));
}
To perform more complex operations you may use [CSharpSyntaxRewriter class][1]. Some examples of using that class may be found at [here][2].
  [1]: https://docs.microsoft.com/en-us/dotnet/api/microsoft.codeanalysis.csharp.csharpsyntaxrewriter?view=roslyn-dotnet
  [2]: https://joshvarty.com/2014/08/15/learn-roslyn-now-part-5-csharpsyntaxrewriter/
