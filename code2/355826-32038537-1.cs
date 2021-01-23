        private string remove_space(string st)
        {
            String final = "";
            char[] b = new char[] { '\r', '\n' };
            String[] lines = st.Split(b, StringSplitOptions.RemoveEmptyEntries);
            foreach (String s in lines)
            {
                if (!String.IsNullOrWhiteSpace(s))
                {
                    final += s;
                    final += Environment.NewLine;
                }
            }
            return final;
        }
