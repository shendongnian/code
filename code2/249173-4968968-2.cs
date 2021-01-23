// You need to include some usings:
using System.Text.RegularExpressions;
using System.Net;
// Then this code (static is not required):
private static Regex hostPortMatch = new Regex(@"^(?<ip>[^:]+)(:(?<port>\d+))?$", System.Text.RegularExpressions.RegexOptions.Compiled);
public static IPEndPoint ParseHostPort(string hostPort)
{
   Match match = hostPortMatch.Match(hostPort);
   if (!match.Success)
      return null;
   return new IPEndPoint(IPAddress.Parse(match.Groups["ip"].Value), int.Parse(match.Groups["port"].Value));
}
