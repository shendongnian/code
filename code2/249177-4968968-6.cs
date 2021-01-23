// You need to include some usings:
using System.Text.RegularExpressions;
using System.Net;
// Then this code (static is not required):
private static Regex hostPortMatch = new Regex(@"^(?&lt;ip&gt;(?:\[[\da-fA-F:]+\])|(?:\d{1,3}\.){3}\d{1,3})(?::(?&lt;port&gt;\d+))?$", System.Text.RegularExpressions.RegexOptions.Compiled);
public static IPEndPoint ParseHostPort(string hostPort)
{
   Match match = hostPortMatch.Match(hostPort);
   if (!match.Success)
      return null;
   return new IPEndPoint(IPAddress.Parse(match.Groups["ip"].Value), int.Parse(match.Groups["port"].Value));
}
