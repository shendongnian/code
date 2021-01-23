    Add-Type @'
    using System.Linq;
    public class Zipper
    {
        public static object[] Zip(object[] first, object[] second)
        {
            return first.Zip(second, (f,s) => new { f , s}).ToArray();
        }
    }
    '@
    $a = 1..4;
    [string[]]$b = "a","b","c","d";
    [Zipper]::Zip($a, $b);
