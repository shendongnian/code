                string s = "JohnMarkMarkMark";
                Regex x = new Regex("Mark");
                MatchCollection m = x.Matches(s);
                if (m!=null && m.Count > 0)
                {
                    s = s.Remove(m[0].Index, m[0].Length);
                    s = s.Insert(m[0].Index,"Tom");
                }
