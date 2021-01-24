String s = "";
for (int i = 3; i < result.Count(); i++)
{
                s = Convert.ToString(result[i]);
                if (s.Contains(macAddress))
                {
                    break;
                }
}
char[] ip = new char[15];
StringBuilder ipaddr = new StringBuilder();
for (int i = 0; s[i].CompareTo(' ') != 0; i++)
{
                ipaddr.Append(s[i]);
}
return ipaddr;
I used each entry in the result list as a string and looked for my MAC as a substring inside all of the entries.
