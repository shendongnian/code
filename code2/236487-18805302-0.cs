    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Web;
    using System.Configuration;
    using System.Globalization;
    namespace SimpleCGIEXE
    {
        class Program
        {
            static string Uni2Html(string src)
            {
                string temp1 = HttpUtility.UrlEncodeUnicode(src);
                string temp2 = temp1.Replace('+', ' ');
                string res = string.Empty;
                int pos1 = 0, pos2 = 0;
                while (true){
                    pos2=temp2.IndexOf("%",pos1);
                    if (pos2 < 0) break;
                    if (temp2[pos2 + 1] == 'u')
                    {
                        res += temp2.Substring(pos1, pos2 - pos1);
                        res += "&#x";
                        res += temp2.Substring(pos2 + 2, 4);
                        res += ";";
                        pos1 = pos2 + 6;
                    }
                    else
                    {
                        res += temp2.Substring(pos1, pos2 - pos1);
                        string stASCII = temp2.Substring(pos2 + 1, 2);
                        byte[] pdASCII = new byte[1];
                        pdASCII[0] = byte.Parse(stASCII, System.Globalization.NumberStyles.AllowHexSpecifier);
                        res += Encoding.ASCII.GetString(pdASCII);
                        pos1 = pos2 + 3;
                    }
                }
                res += temp2.Substring(pos1);
                return res;
            }
            static void Main(string[] args)
            {
                Console.WriteLine("Content-type: text/html;charset=utf-8\r\n");
                String st = "Unicode string: Thử một xâu thật dài @@ # ~ .^ % !";
                Console.WriteLine(Uni2Html(st));
            }
        }
    }
