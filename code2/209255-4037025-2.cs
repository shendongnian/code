    private List<Tuple<int, Action>> m_upgradeList;
    
    public Program()
    {
        m_upgradeList = new List<Tuple<int, Action>> {
            Tuple.Create(1001, new Action(updateTo1002)),
            Tuple.Create(1002, new Action(updateTo1003)),
            Tuple.Create(1003, new Action(updateTo1004)),
            Tuple.Create(1004, new Action(updateTo1005)),
        };
    }
    
    public void Upgrade(int version)
    {
        foreach (var tuple in m_upgradeList)
        {
            if (version <= tuple.Item1)
            {
                tuple.Item2();
            }
        }
    }
