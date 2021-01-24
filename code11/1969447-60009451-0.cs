csharp
using System;
using System.Text;
using System.Web;
static class Program
{
    public static void Main()
    {
        string encoded = "Tu%C4%9F%C3%A7e%20Kandemir%20-%20G%C3%BCl%C3%BC%20Soldurmam.mp3";
        string decoded = HttpUtility.UrlDecode(encoded, Encoding.UTF8);
        foreach (char c in decoded)
        {
            Console.WriteLine($"{c}: U+{(int) c:X4}");
        }
    }
}
Output - on a console set to UTF-8 just to make sure all characters can be displayed, but I've printed out the Unicode numbers as well, for clarity:
text
T: U+0054
u: U+0075
ğ: U+011F
ç: U+00E7
e: U+0065
 : U+0020
K: U+004B
a: U+0061
n: U+006E
d: U+0064
e: U+0065
m: U+006D
i: U+0069
r: U+0072
 : U+0020
-: U+002D
 : U+0020
G: U+0047
ü: U+00FC
l: U+006C
ü: U+00FC
 : U+0020
S: U+0053
o: U+006F
l: U+006C
d: U+0064
u: U+0075
r: U+0072
m: U+006D
a: U+0061
m: U+006D
.: U+002E
m: U+006D
p: U+0070
3: U+0033
