csharp
public class AuthorizationRuleEqualityComparer : IEqualityComparer<AuthorizationRule>
{
    public static readonly AuthorizationRuleEqualityComparer Instance = new AuthorizationRuleEqualityComparer();
    private AuthorizationRuleEqualityComparer()
    {
    }
    public bool Equals(AuthorizationRule l, AuthorizationRule r)
    {
        // Compare more fields if needed.
        return l.IdentityReference == r.IdentityReference;
    }
    public int GetHashCode(AuthorizationRule rule)
    {
        return rule.IdentityReference.GetHashCode();
    }
}
Usage:
csharp
AuthorizationRuleCollection arc1;
AuthorizationRuleCollection arc2;
var equal = arc1
    .OfType<AuthorizationRule>()
    .SequenceEqual(
        arc2.OfType<AuthorizationRule>(),
        AuthorizationRuleEqualityComparer.Instance);
