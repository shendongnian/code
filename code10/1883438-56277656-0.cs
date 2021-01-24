    using System;
    using System.Text.RegularExpressions;
    public class Example
    {
        public static void Main()
        {
            string pattern = @"=»([0-9]+)";
            string input = @"> login as: LOGIN SERVER@00.00.00.000's password: Last login: Thu May 23
    > 15:51:49 2019 from 00.00.00.000 CREER AUTANT DE REPERTOIRES SOUS
    > /NAME/NAME/NAME QU'IL Y A DE COMMERCANTS GERES. LE NOM DOIT ETRE LE NO
    > DE COMMERCANT. CREER ENSUITE SOUS CHACUN D'EUX UN REPERTOIRE NAME/
    > <SERVER>ps -fu NAME | grep exe | echo «resultat=»`wc -l` «resultat=»14
    > <SERVER>";
            RegexOptions options = RegexOptions.Multiline;
            
            foreach (Match m in Regex.Matches(input, pattern, options))
            {
                Console.WriteLine("'{0}' found at index {1}.", m.Value, m.Index);
            }
        }
    }
