    using System;
    using System.Text.RegularExpressions;
    
    namespace ConsoleApp1 {
        class Program {
            static void Main(string[] args) {
                var rcv =
                      "T000652706314602   17.000                            1R0C_MARA_NTGEW\n"
                    + "T000652706314602   17.300                            1R0C_MARA_NTGEW\n"
                    + "T000652706314602   17.030                            1R0C_MARA_NTGEW\n"
                    + "T000652706314602   17.003                            1R0C_MARA_NTGEW";
    
                var rex = new Regex(@"^T\d{12}602\s+(\d+\.\d+)\s+", RegexOptions.Multiline);
                foreach (Match match in rex.Matches(rcv)) {
                    Console.WriteLine("found a match: " + match.Groups[1]);
                }
    
                Console.ReadLine();
            }
        }
    }
