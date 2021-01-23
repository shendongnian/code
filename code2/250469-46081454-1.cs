    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions; 
    
    namespace Grappachu.Movideo.Core.Helpers.TitleCleaner
    {
        public class MovieTitleCleanerResult
        {
            public string Title { get; set; }
            public int? Year { get; set; }
            public string SubTitle { get; set; }
        }
    
        public class MovieTitleCleaner
        {
            private const string SpecialMarker = "§=§";
            private static readonly string[] ReservedWords;
            private static readonly string[] SpaceChars;
            private static readonly string[] Languages;
    
            static MovieTitleCleaner()
            {
                ReservedWords = new[]
                {
                    SpecialMarker, "hevc", "bdrip", "Bluray", "x264", "h264", "AC3", "DTS", "480p", "720p", "1080p"
                };
                var cultures = CultureInfo.GetCultures(CultureTypes.AllCultures);
                var l = cultures.Select(x => x.EnglishName).ToList();
                l.AddRange(cultures.Select(x => x.ThreeLetterISOLanguageName));
                Languages = l.Distinct().ToArray();
    
    
                SpaceChars = new[] {".", "_", " "};
            }
    
    
            public static MovieTitleCleanerResult Clean(string filename)
            {
                var temp = Path.GetFileNameWithoutExtension(filename);
                int? maybeYear = null;
    
                // Remove what's inside brackets trying to keep year info.
                temp = RemoveBrackets(temp, '{', '}', ref maybeYear);
                temp = RemoveBrackets(temp, '[', ']', ref maybeYear);
                temp = RemoveBrackets(temp, '(', ')', ref maybeYear);
    
                // Removes special markers (codec, formats, ecc...)
                var tokens = temp.Split(SpaceChars, StringSplitOptions.RemoveEmptyEntries);
                var title = string.Empty;
                for (var i = 0; i < tokens.Length; i++)
                {
                    var tok = tokens[i];
                    if (ReservedWords.Any(x => string.Equals(x, tok, StringComparison.OrdinalIgnoreCase)))
                    {
                        if (title.Length > 0)
                            break;
                    }
                    else
                    {
                        title = string.Join(" ", title, tok).Trim();
                    }
                }
                temp = title;
    
                // Remove languages infos when are found before special markers (should not remove "English" if it's inside the title)
                tokens = temp.Split(SpaceChars, StringSplitOptions.RemoveEmptyEntries);
                for (var i = tokens.Length - 1; i >= 0; i--)
                {
                    var tok = tokens[i];
                    if (Languages.Any(x => string.Equals(x, tok, StringComparison.OrdinalIgnoreCase)))
                        tokens[i] = string.Empty;
                    else
                        break;
                }
                title = string.Join(" ", tokens).Trim();
    
    
                // If year is not found inside parenthesis try to catch at the end, just after the title
                if (!maybeYear.HasValue)
                {
                    var resplit = title.Split(SpaceChars, StringSplitOptions.RemoveEmptyEntries);
                    var last = resplit.Last();
                    if (LooksLikeYear(last))
                    {
                        maybeYear = int.Parse(last);
                        title = title.Replace(last, string.Empty).Trim();
                    }
                }
    
    
                // TODO: review this. when there's one dash separates main title from subtitle 
                var res = new MovieTitleCleanerResult();
                res.Year = maybeYear;
                if (title.Count(x => x == '-') == 1)
                {
                    var sp = title.Split('-');
                    res.Title = sp[0];
                    res.SubTitle = sp[1];
                }
                else
                {
                    res.Title = title;
                }
    
    
                return res;
            }
    
            private static string RemoveBrackets(string inputString, char openChar, char closeChar, ref int? maybeYear)
            {
                var str = inputString;
                while (str.IndexOf(openChar) > 0 && str.IndexOf(closeChar) > 0)
                {
                    var dataGraph = str.GetBetween(openChar.ToString(), closeChar.ToString());
                    if (LooksLikeYear(dataGraph))
                    {
                        maybeYear = int.Parse(dataGraph);
                    }
                    else
                    {
                        var parts = dataGraph.Split(SpaceChars, StringSplitOptions.RemoveEmptyEntries);
                        foreach (var part in parts)
                            if (LooksLikeYear(part))
                            {
                                maybeYear = int.Parse(part);
                                break;
                            }
                    }
                    str = str.ReplaceBetween(openChar, closeChar, string.Format(" {0} ", SpecialMarker));
                }
                return str;
            }
    
            private static bool LooksLikeYear(string dataRound)
            {
                return Regex.IsMatch(dataRound, "^(19|20)[0-9][0-9]");
            }
        }
    
    
        public static class StringUtils
        {
            public static string GetBetween(this string src, string a, string b,
                StringComparison comparison = StringComparison.Ordinal)
            {
                var idxStr = src.IndexOf(a, comparison);
                var idxEnd = src.IndexOf(b, comparison);
                if (idxStr >= 0 && idxEnd > 0)
                {
                    if (idxStr > idxEnd)
                        Swap(ref idxStr, ref idxEnd);
                    return src.Substring(idxStr + a.Length, idxEnd - idxStr - a.Length);
                }
                return src;
            }
    
            private static void Swap<T>(ref T idxStr, ref T idxEnd)
            {
                var temp = idxEnd;
                idxEnd = idxStr;
                idxStr = temp;
            }
    
            public static string ReplaceBetween(this string s, char begin, char end, string replacement = null)
            {
                var regex = new Regex(string.Format("\\{0}.*?\\{1}", begin, end));
                return regex.Replace(s, replacement ?? string.Empty);
            }
        }
    }
 
