using System;
using System.Text;
using iTextSharp.text.pdf;
namespace PdfExtractor
{
    class Program
    {
        static void Main(string[] args)
        {
            var reader = new PdfReader(@"D:\Tmp\sample.pdf");
            try
            {
                var parser = new PdfContentParser(new PRTokeniser(reader.GetPageContent(2)));
                var sb = new StringBuilder();
                while (parser.Tokeniser.NextToken())
                {
                    if (parser.Tokeniser.TokenType == PRTokeniser.TK_STRING)
                    {
                        string str = parser.Tokeniser.StringValue;
                        sb.Append(str);
                    }
                }
                Console.WriteLine(sb.ToString());
            }
            finally {
                reader.Close();
            }
        }
    }
}
