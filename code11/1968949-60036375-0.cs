 C#
public static class CultureInfoExtensions
{
    public static bool MatchesWith(this CultureInfo cultureInfo, CultureInfo matchCandidate)
    {
        if (cultureInfo == CultureInfo.InvariantCulture)
        {
            return false;
        }
        return cultureInfo.Equals(matchCandidate) || cultureInfo.Parent.MatchesWith(matchCandidate);
    }
}
Sharing this with other people that are going to have this problem, since there are not many topics online about this.
