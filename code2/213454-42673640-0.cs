    private String CorrectName(String name)
            {
                List<String> StringsToCapitalizeAfter = new List<String>() { " ", "-", "Mc" };
                StringBuilder NameBuilder = new StringBuilder();
                name.Select(c => c.ToString()).ToList().ForEach(c =>
                {
                    c = c.ToLower();
                    new List<String>() { " ", "-", "Mc" }.ForEach(s =>
                    {
                        if(String.IsNullOrEmpty(NameBuilder.ToString()) || NameBuilder.ToString().EndsWith(s))
                        {
                            c = c.ToUpper();
                        }
                    });
                    NameBuilder.Append(c);
                });
                return NameBuilder.ToString();
            }
