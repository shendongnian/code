    public List<String> result;
    public void GetResultList(int startOffs, String CurNames, int curTotal)
    {
      for (int newOffs = startOffs; newOffs < _sections.Count; newOffs++)
      {
        int newTotal = curTotal + _sections[newOffs].Pages;
    	String newNames = CurNames+ _sections[newOffs].Name;
    	if (newTotal < _targetPage)
    	  GetResultList(newOffs, newNames, newTotal);
    	else if (newTotal == _targetPage)
    	  result.Add(newNames);
      }
    }
