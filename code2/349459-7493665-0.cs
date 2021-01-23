    private string BuildSQL(List<SomeType> param)
            {
                string res = "1=1";
    
                if (param != null && param.Count > 0)
                {
                    foreach (SomeType type in param)
                    {
                        res += " OR (A.Key='" + type.Key + "' AND A.ModificationDate < '" + type.ModificationDate + "')";
                    }
                }
    
                return res;
            }
