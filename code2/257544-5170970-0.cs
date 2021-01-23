    private string RemoveImages(string html)
            {
                StringBuilder retval = new StringBuilder();
                using (StringReader reader = new StringReader(html))
                {
                    string line = string.Empty;
                    do
                    {
                        line = reader.ReadLine();
                        if (line != null)
                        {
                            if (!line.StartsWith("<img"))
                            {
                               retval.Append(line); 
                            }
                        }
    
                    } while (line != null);
                }
                return retval.ToString();
            }
