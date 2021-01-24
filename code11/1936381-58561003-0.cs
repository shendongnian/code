      public static string RemoveCharSpecials(string document)
        {
            var charsToRemove = new string[] { "@", ",", ".", ";", "'", "(", ")", "-", " ", "/" };
            try
            {
                if (!string.IsNullOrEmpty(document))
                {
                    foreach (var c in charsToRemove)
                        document = document.Replace(c, string.Empty);
                }
                return document;
            }
            catch
            {
                return "";
            }
        }
