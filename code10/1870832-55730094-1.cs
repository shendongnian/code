    public void GetResultList(int startOffs, Config CurConfig)
    {
      for (int newOffs = startOffs; newOffs < _sections.Count; newOffs++)
      {
        Config newConfig = new Config{ Name = CurConfig.Name + _sections[newOffs].Name,
    	                               Ids = CurConfig.Ids + _sections[newOffs].Id.ToString(),
    								   Pages = CurConfig.Pages + _sections[newOffs].Pages};
    	if (newConfig.Pages < _targetPage)
    	  GetResultList(newOffs, newConfig);
    	else if (newConfig.Pages == _targetPage)
    	  _result.Add(newConfig);
      }
    }
