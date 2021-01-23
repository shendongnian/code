        private int GetNumber(string t)
        {
            int result;
            if(Int32.TryParse(t.Substring(0, t.Length - 1), out result) == false)
            {
                 // you can handle here incorrect 't' value if you want
            }
            return result;
        }
