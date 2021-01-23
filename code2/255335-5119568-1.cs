    string sCorpFilter = m_sc.get_Corp();
    IEnumerable<string> corps = null;
    if (! string.IsNullOrEmpty(sCorpFilter))
    {
      corps = sCorpFilter.Split(",".ToCharArray(),
       StringSplitOptions.RemoveEmptyEntries).Select(s => s.Trim());
    }
    [...]
    if (corps != null && corps.Contains(AgentID))
    {
      found = true;
    }
