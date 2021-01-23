    public class SSwap
    {
        string str1 = @"<div class=""bb"" id=""aaa"">";
        string str2 = @"<div class=""bb"" style=""kk"" id=""aaa"">";
        public SSwap()
        {
            Console.WriteLine("Before : " + str1 + "\nAfter : " + swap_string(str1));
            Console.WriteLine("Before : " + str2 + "\nAfter : " + swap_string(str2));
        }
        public string swap_string(string str)
        {
            string retStr = "<div ";
            Regex theRegex = new Regex(@"(\w+)=(""\w+"")");
            Dictionary<string, string> props = new Dictionary<string, string>();
            Match m = theRegex.Match(str);
            int classPos=-1, idPos=-1, pos = 0;
            while (m.Success)
            {
                if (m.Result("$1") == "class") classPos = pos; // Remember where class was
                if (m.Result("$1") == "id") idPos = pos; // Remember where id was
                props[m.Result("$1")] = m.Result("$2");
                m = m.NextMatch();
                pos++;
            }
            pos = 0;
            foreach (string s in props.Keys)
            {
                if (pos == classPos)  // put id where class was
                {
                    retStr += @"id=" + props["id"] + @" ";
                }
                else if (pos == idPos) // put class where id was
                {
                    retStr += @"class=" + props["class"] + @" ";
                }
                else // put everything else where ever it appears in the dictionary
                {
                    retStr += s + @"=" + props[s] + @" ";
                }
                pos++;
            }
            retStr += ">";
            return retStr;
        }
     }
