c#
{
    ...
    .And.OnlyContain(rel => CheckUrl(rel));
}
private static bool CheckUrl(Relation rel)
{
    // you can set a breakpoint here
    return rel.RelationType.MatchTo(RelationType.ArtifactLink) && 
    rel.Href.AbsoluteUri.StartsWith(VsTfsSchema.GitPullRequestId);
}
