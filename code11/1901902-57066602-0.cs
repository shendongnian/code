    using System.Collections.Generic;
    using System.Linq;
    namespace ConsoleApp6
    {
        internal class Program
        {
            private enum Token
            {
                Open,
                Close,
                Char,
                UnKnowChar,
                Space,
                NewLine,
            }
            private static void Main(string[] args)
            {
                var text = @"{
        ABC
        DEF
    }
    {
        GHI
        LMN
    }
    {
        QWE
        ERT
    }
    ";
                var strings = Parse(text).ToArray();
            }
            private static IEnumerable<string> Parse(string text)
            {
                var strings = new List<string>();
                var tokens = GetTokens(text);
                var opens = tokens.Select((token, index) => new {token, index})
                    .Where(list => list.token == Token.Open).ToList();
                foreach (var open in opens)
                {
                    var index = tokens.FindIndex(open.index, token => token == Token.Close);
                    var substring = text.Substring(open.index + 1, index - open.index - 1);
                    var trim = substring.Trim('\r', '\n', ' ');
                    strings.Add(trim.Replace(' '.ToString(), string.Empty));
                }
                return strings;
            }
            private static List<Token> GetTokens(string text)
            {
                var tokens = new List<Token>();
                foreach (var _char in text)
                    switch (_char)
                    {
                        case ' ':
                            tokens.Add(Token.Space);
                            break;
                        case '\r':
                        case '\n':
                            tokens.Add(Token.NewLine);
                            break;
                        case '{':
                            tokens.Add(Token.Open);
                            break;
                        case '}':
                            tokens.Add(Token.Close);
                            break;
                        case 'A':
                        case 'B':
                        case 'C':
                        case 'D':
                        case 'E':
                        case 'F':
                        case 'G':
                        case 'H':
                        case 'I':
                        case 'J':
                        case 'K':
                        case 'L':
                        case 'M':
                        case 'N':
                        case 'O':
                        case 'P':
                        case 'Q':
                        case 'R':
                        case 'S':
                        case 'T':
                        case 'U':
                        case 'V':
                        case 'W':
                        case 'X':
                        case 'Y':
                        case 'Z':
                            tokens.Add(Token.Char);
                            break;
                        default:
                            tokens.Add(Token.UnKnowChar);
                            break;
                    }
                return tokens;
            }
        }
    }
