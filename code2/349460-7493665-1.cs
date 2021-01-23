        private string BuildSQL(List<SomeType> param)
                {
                    string res = string.Empty;
        
                    if (param != null && param.Count > 0)
                    {
                        foreach (SomeType type in param)
                        {
                            res += " (A.Key='" + type.Key + "' AND A.ModificationDate < '" + type.ModificationDate + "') OR";
                        }
                    }
        if(!string.IsNullOrEmpty(res))
    {
    res = res.Substring(0, res.Length - 3);
    }
                    return res;
                }
