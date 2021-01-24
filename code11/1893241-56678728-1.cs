    using System;
    using System.Text.RegularExpressions;
    
    public class Example
    {
        public static void Main()
        {
            string pattern = @"\b([A-Z]{2})\b\s{2,}.*\s{2,}(.+)";
            string input = @"DADOS DO FABRICANTE
    * CNPJ/CPF           UF    Quantidade Peso Líquido(kg)   Vl.Moeda
    - 99.999.999/9999-99 MN    4,00000    212,00000          250.400,00
    Obs:
    - 99.999.999/9999-99 AB    4,00000    212,00000          250.400,00000
    Obs:
    - 99.999.999/9999-99 XZ    4,00000    212,00000          250.400,00000
    Obs:";
            RegexOptions options = RegexOptions.Multiline;
            
            foreach (Match m in Regex.Matches(input, pattern, options))
            {
                Console.WriteLine("'{0}' found at index {1}.", m.Value, m.Index);
            }
        }
    }
