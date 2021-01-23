C#
//remove vowels in string in C#
string s = "saravanan";
string res = "";
char[] ch = { 'a', 'e', 'i', 'o', 'u' } ;
foreach (char c in ch)
{
    for (int i = 0; i < s.Length; i++)
    {
        if (s[i] == c)
        {
            res = res + "";
        }
        else
        {
            res = res + s[i];
        }
    }
    break;
}
Console.WriteLine(res);
Console.ReadLine();
