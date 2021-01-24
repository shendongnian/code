    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Text.RegularExpressions;
    using System.Globalization;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.txt";
            static void Main(string[] args)
            {
                MT940 mt940 = new MT940(FILENAME);
            }
        }
        public class MT940
        {
            const string TAG_PATTERN = @"^:(?'tag'[^:]+):(?'value'.*)";
            public string senderReference { get; set; }  //code 20
            public string authorisation { get; set; } // tag 25
            public string messageIndexTotal { get; set; } //tag 28D
            public Currency openingBalance { get; set; }  //60F
            public string firstTransaction { get; set; } //61
            public string secondTransaction { get; set; } //61
            public Currency closingBalance { get; set; } //62F
            public MT940(string filename)
            {
                StreamReader reader = new StreamReader(filename);
                string line = "";
                int transactionCount = 0;
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.StartsWith(":"))
                    {
                        Match match = Regex.Match(line, TAG_PATTERN);
                        string tag = match.Groups["tag"].Value;
                        string value = match.Groups["value"].Value;
                        switch (tag)
                        {
                            case "20":
                                senderReference = value;
                                break;
                            case "25":
                                authorisation = value;
                                break;
                            case "28C":
                                messageIndexTotal = value;
                                break;
                            case "60F":
                                openingBalance = new Currency(value);
                                break;
                            case "61":
                                if (++transactionCount == 1)
                                {
                                    firstTransaction = value;
                                }
                                else
                                {
                                    secondTransaction = value;
                                }
                                break;
                            case "62F":
                                closingBalance = new Currency(value);
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
        }
        public class Currency
        {
            const string BALANCE_PATTERN = @"^(?'credit_debit'.)(?'date'.{6})(?'country_code'.{3})(?'amount'.*)";
            static CultureInfo culture = CultureInfo.GetCultureInfoByIetfLanguageTag("da");
            public DateTime date { get; set; }
            public string currencyCode { get; set; }
            public decimal amount { get; set; }
            public Currency(string input)
            {
                Match match = Regex.Match(input, BALANCE_PATTERN);
                string credit_debit = match.Groups["credit_debit"].Value;
                string dateStr = match.Groups["date"].Value;
                date = DateTime.ParseExact(dateStr, "yyMMdd", CultureInfo.InvariantCulture);
                currencyCode = match.Groups["country_code"].Value;
                string amountStr = match.Groups["amount"].Value;
                amount = decimal.Parse(amountStr, culture);
                amount *= credit_debit == "D" ? -1 : 1;
            }
        }
    }
