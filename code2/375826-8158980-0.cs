    private prmMatrix[] _allParams;
    private List<String> _allCombos;
    public List<String> EnumarateAllCombinations()
    {
       _allCombos = new List<String>();
       EnumParams(0, "");
       return _allCombos;
    }
    private void EnumParams(int paramNum, string paramValues)
    {
        if(paramNum >= allParams.Length)
        {
            _allCombos.add(paramValues);
        }
        else
        {
            prmMatrix current = _allParams[paramNum];
            foreach(string val in current.PossibleValues)
                EnumParams(paramNum+1, paramValues + "[" + val + "]");
        }
     }
    }
