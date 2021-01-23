    public static string ConvertNumericalPinYinToAccented(string input)
        {
            Dictionary<int, string> PinyinToneMark = new Dictionary<int, string>
            {
                {0, "aoeiuv\u00fc"},
                {1, "\u0101\u014d\u0113\u012b\u016b\u01d6\u01d6"},
                {2, "\u00e1\u00f3\u00e9\u00ed\u00fa\u01d8\u01d8"},
                {3, "\u01ce\u01d2\u011b\u01d0\u01d4\u01da\u01da"},
                {4, "\u00e0\u00f2\u00e8\u00ec\u00f9\u01dc\u01dc"}
            };
            string[] words = input.Split(' ');
            string accented = "";
            string t = "";
            foreach (string pinyin in words)
            {
                foreach (char c in pinyin)
                {
                    string lowerpinyin = pinyin.ToLower();
                    if (c >= 'a' & c <= 'z')
                    {
                        t += c;
                    }
                    else if (c == ':')
                    {
                        if (t[t.Length - 1] == 'u')
                        {
                            t = t.Substring(0, t.Length - 2) + "\u00fc";
                        }
                    }
                    else
                    {
                        if (c >= '0' & c <= '5')
                        {
                            int tone = (int)Char.GetNumericValue(c) % 5;
                            if (tone != 0)
                            {
                                Match match = Regex.Match(t, "[aoeiuv\u00fc]+");
                                if (!match.Success)
                                {
                                    t += c;
                                }
                                else if (match.Groups[0].Length == 1)
                                {
                                    t = t.Substring(0, match.Groups[0].Index) +
                                        PinyinToneMark[tone][PinyinToneMark[0].IndexOf(match.Groups[0].Value[0])]
                                        + t.Substring(match.Groups[0].Index + match.Groups[0].Length);
                                }
                                else
                                {
                                    if (t.Contains("a"))
                                    {
                                        t = t.Replace("a", PinyinToneMark[tone][0].ToString());
                                    }
                                    else if (t.Contains("o"))
                                    {
                                        t = t.Replace("o", PinyinToneMark[tone][1].ToString());
                                    }
                                    else if (t.Contains("e"))
                                    {
                                        t = t.Replace("e", PinyinToneMark[tone][2].ToString());
                                    }
                                    else if (t.Contains("ui"))
                                    {
                                        t = t.Replace("i", PinyinToneMark[tone][3].ToString());
                                    }
                                    else if (t.Contains("iu"))
                                    {
                                        t = t.Replace("u", PinyinToneMark[tone][4].ToString());
                                    }
                                    else
                                    {
                                        t += "!";
                                    }
                                }
                            }
                        }
                        accented += t;
                        t = "";
                    }
                }
                accented += t + " ";
            }
            accented = accented.TrimEnd();
            return accented;
        }
