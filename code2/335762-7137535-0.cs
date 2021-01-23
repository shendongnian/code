    const string format = @"hh\:mm\:ss\,fff";
            static void Main(string[] args)
            {
                string input = File.ReadAllText("sb.srt");
                Regex r = new Regex(@"(\d\d):(\d\d):(\d\d),(\d\d\d)");
                input = r.Replace(input, m=> AddTime(m));
                File.WriteAllText("sb.srt", input);
            }
    
            private static string AddTime(Match m)
            {
                TimeSpan t = TimeSpan.ParseExact(m.Value, format, CultureInfo.InvariantCulture);
                t += new TimeSpan(0, 1, 0);
                return t.ToString(format);
            }
