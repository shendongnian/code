        protected void Page_Load(object sender, EventArgs e)
        {
            CheckValue("fefe[][]12#");
            CheckValue("abvds");
            CheckValue("#");
            CheckValue(@"[][][][][]\\\\\][]");
            CheckValue("^^^efewfew[[]");
        }
        public static string CheckValue(string value)
        {
            StringBuilder sBuilder = new StringBuilder(value);
            string pattern = @"([-\]\[<>\?\*\\\""/\|\~\(\)\#/=><+\%&\^\'])";
            Regex expression = new Regex(pattern);
            if (expression.IsMatch(value))
            {
                sBuilder.Insert(0, "[");
                sBuilder.Append("]");
                sBuilder.Replace(@"\", @"\\");
                sBuilder.Replace("]", @"\]");                
            }
            return sBuilder.ToString();
        }
