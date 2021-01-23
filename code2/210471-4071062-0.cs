            private string SanitizeXml(string source)
            {
                if (source.IsNullOrEmpty())
                {
                    return source;
                }
                if (source.IndexOf('&') < 0)
                {
                    return source;
                }
                StringBuilder result = new StringBuilder(source);
                result = result.Replace("&lt;", "<>lt;")
                                .Replace("&gt;", "<>gt;")
                                .Replace("&amp;", "<>amp;")
                                .Replace("&apos;", "<>apos;")
                                .Replace("&quot;", "<>quot;");
                result = result.Replace("&", "&amp;");
                result = result.Replace("<>lt;", "&lt;")
                                .Replace("<>gt;", "&gt;")
                                .Replace("<>amp;", "&amp;")
                                .Replace("<>apos;", "&apos;")
                                .Replace("<>quot;", "&quot;");
    
                return result.ToString();
            }
