    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string s = "src='/pages/captcha?t=c&s=51afb384edfc&h=513cc6f5349b' </td><td><input type=text name=captchaenter id=captchaenter size=3";
                Regex rgx = new Regex("src=\\'/pages/captcha\\?t=c&s=([\\d\\w\\W]+)\\'", RegexOptions.IgnoreCase);
                Match m = rgx.Match(s);
                Console.Write(m.Groups[1]);
            }
        }
    }
