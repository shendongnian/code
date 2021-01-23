    public static class XHTMLCleanerUpperThingy
    {
        private const string p = "<p>";
        private const string closingp = "</p>";
        public static string CleanUpXHTML(string xhtml)
        {
            StringBuilder builder = new StringBuilder(xhtml);
            for (int idx = 0; idx < xhtml.Length; idx++)
            {
                int current;
                if ((current = xhtml.IndexOf(p, idx)) != -1)
                {
                    int idxofnext = xhtml.IndexOf(p, current + p.Length);
                    int idxofclose = xhtml.IndexOf(closingp, current);
                    // if there is a next <p> tag
                    if (idxofnext > 0)
                    {
                        // if the next closing tag is farther than the next <p> tag
                        if (idxofnext < idxofclose)
                        {
                            for (int j = 0; j < p.Length; j++)
                            {
                                builder[current + j] = ' ';
                            }
                        }
                    }
                    // if there is not a final closing tag
                    else if (idxofclose < 0)
                    {
                        for (int j = 0; j < p.Length; j++)
                        {
                            builder[current + j] = ' ';
                        }
                    }
                }
            }
            return builder.ToString();
        }
    }
