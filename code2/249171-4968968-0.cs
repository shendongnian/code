public static void ParseHostString(string hostString, ref string hostName, ref int port)
{
   hostName = hostString;
   if (hostString.Contains(":"))
   {
      string[] hostParts = hostString.Split(':');
      if (hostParts.Length == 2)
      {
         hostName = hostParts[0];
         int.TryParse(hostParts[1], out port);
      }
   }
}
