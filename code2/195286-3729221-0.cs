    class Program
    {
        private const string PATTERN = @".style[\d]+{[^}]*}";
        private const string STYLE_STRING = @"  .right {          }      td{         }   table{          }   .style1{          }   .style2{          }   .style15{          }  .style20{        }";
        static void Main(string[] args)
        {
            var matches = Regex.Matches(STYLE_STRING, PATTERN);
            var styleList = new List<string>();
            for (int i = 0; i < matches.Count; i++)
            {
                styleList.Add(matches[i].ToString());
            }
            styleList.ForEach(Console.WriteLine);
            Console.ReadLine();
        }
    }
