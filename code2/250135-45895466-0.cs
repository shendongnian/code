    private List<string> lstOfConstants= new List<string>();
        foreach (var constant in typeof(TestClass).GetFields())
        {
            if (constant.IsLiteral && !constant.IsInitOnly)
            {
                lstOfConstants.Add((string)constant.GetValue(null));
            }
        }
